using System;
using _03_Bank;

// Passo 1: Criar objetos BankCustomer
Console.WriteLine("Criando objetos BankCustomer...");
string firstName = "Leonardo";
string lastName = "Moura";

BankCustomer customer1 = new BankCustomer(firstName, lastName);

firstName = "Arthur";
BankCustomer customer2 = new BankCustomer(firstName, lastName);

firstName = "Gabriela";
lastName = "Mendes";
BankCustomer customer3 = new BankCustomer(firstName, lastName);

Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");

// Passo 2: Criar objetos BankAccount para os clientes
Console.WriteLine("\nCriando objetos BankAccount para os clientes...");
BankAccount account1 = new BankAccount(customer1.CustomerId);
BankAccount account2 = new BankAccount(customer2.CustomerId, 1500, "Checking");
BankAccount account3 = new BankAccount(customer3.CustomerId, 2500, "Checking");

Console.WriteLine($"Conta 1: Nº {account1.AccountNumber}, tipo {account1.AccountType}, saldo {account1.Balance}, taxa {BankAccount.InterestRate}, ID do cliente {account1.CustomerId}");
Console.WriteLine($"Conta 2: Nº {account2.AccountNumber}, tipo {account2.AccountType}, saldo {account2.Balance}, taxa {BankAccount.InterestRate}, ID do cliente {account2.CustomerId}");
Console.WriteLine($"Conta 3: Nº {account3.AccountNumber}, tipo {account3.AccountType}, saldo {account3.Balance}, taxa {BankAccount.InterestRate}, ID do cliente {account3.CustomerId}");

// Passo 3: Demonstrar o uso das propriedades de BankCustomer
Console.WriteLine("\nAtualizando o nome do BankCustomer 1...");
customer1.FirstName = "Leonardo";
customer1.LastName = "Moura dos Santos de Jesus";
Console.WriteLine($"BankCustomer 1 atualizado: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");

// Passo 4: Demonstrar o uso dos métodos de BankAccount
Console.WriteLine("\nDemonstrando métodos de BankAccount...");

// Depósito
Console.WriteLine("Depositando 500 na Conta 1...");
account1.Deposit(500);
Console.WriteLine($"Conta 1 após depósito: Saldo = {account1.Balance}");

// Saque
Console.WriteLine("Sacando 200 da Conta 2...");
bool withdrawSuccess = account2.Withdraw(200);
Console.WriteLine($"Conta 2 após saque: Saldo = {account2.Balance}, Saque realizado: {withdrawSuccess}");

// Transferência
Console.WriteLine("Transferindo 300 da Conta 3 para a Conta 1...");
bool transferSuccess = account3.Transfer(account1, 300);
Console.WriteLine($"Conta 3 após transferência: Saldo = {account3.Balance}, Transferência realizada: {transferSuccess}");
Console.WriteLine($"Conta 1 após receber transferência: Saldo = {account1.Balance}");

// Aplicar juros
Console.WriteLine("Aplicando juros à Conta 1...");
account1.ApplyInterest();
Console.WriteLine($"Conta 1 após aplicar juros: Saldo = {account1.Balance}");

// Passo 5: Demonstrar o uso de métodos de extensão
Console.WriteLine("\nDemonstrando métodos de extensão...");
Console.WriteLine(customer1.GreetCustomer());
Console.WriteLine($"O ID do cliente 1 é válido? {customer1.IsValidCustomerId()}");
Console.WriteLine($"A conta 2 pode sacar 2000? {account2.CanWithdraw(2000)}");
Console.WriteLine($"A conta 3 está no vermelho? {account3.IsOverdrawn()}");

// Passo 6: Exibir informações dos clientes e contas
Console.WriteLine("\nExibindo informações dos clientes e contas...");
Console.WriteLine(customer1.DisplayCustomerInfo());
Console.WriteLine(account1.DisplayAccountInfo());
