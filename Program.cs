using System;
using System.Globalization;
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
Console.WriteLine("\nDemonstrando métodos da BankAccount...");

// Depósito
double depositAmount = 500;
Console.WriteLine($"Depositando {depositAmount.ToString("C", CultureInfo.CurrentCulture)} na Conta 1...");
account1.Deposit(depositAmount);
Console.WriteLine($"Conta 1 após depósito: Saldo = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

// Saque
double withdrawalAmount = 200;
Console.WriteLine($"Sacando {withdrawalAmount.ToString("C", CultureInfo.CurrentCulture)} da Conta 2...");
bool withdrawSuccess = account2.Withdraw(withdrawalAmount);
Console.WriteLine($"Conta 2 após saque: Saldo = {account2.Balance.ToString("C", CultureInfo.CurrentCulture)}, Saque bem-sucedido: {withdrawSuccess}");

// Transferência
double transferAmount = 300;
Console.WriteLine($"Transferindo {transferAmount.ToString("C", CultureInfo.CurrentCulture)} da Conta 3 para a Conta 1...");
bool transferSuccess = account3.Transfer(account1, transferAmount);
Console.WriteLine($"Conta 3 após transferência: Saldo = {account3.Balance.ToString("C", CultureInfo.CurrentCulture)}, Transferência bem-sucedida: {transferSuccess}");
Console.WriteLine($"Conta 1 após receber transferência: Saldo = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

// Demonstrar uso dos métodos utilitários da AccountCalculations
Console.WriteLine("\nDemonstrando métodos utilitários da AccountCalculations...");

// Calcular juros compostos para a conta1
double principal = account1.Balance;
double rate = BankAccount.InterestRate;
double time = 1; // 1 ano
double compoundInterest = AccountCalculations.CalculateCompoundInterest(principal, rate, time);
Console.WriteLine($"Juros compostos sobre o saldo da conta1 de {principal.ToString("C", CultureInfo.CurrentCulture)} a {rate * 100:F2}% por {time} ano: {compoundInterest.ToString("C", CultureInfo.CurrentCulture)}");

// Validar número da conta para a conta1
int accountNumber = account1.AccountNumber;
bool isValidAccountNumber = AccountCalculations.ValidateAccountNumber(accountNumber);
Console.WriteLine($"O número da conta {accountNumber} é válido? {isValidAccountNumber}");

// Calcular taxa de transação usando valores e taxas da classe BankAccount
double transactionAmount = 800;
double transactionFee = AccountCalculations.CalculateTransactionFee(transactionAmount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
Console.WriteLine($"Taxa de transação para uma transferência de {transactionAmount.ToString("C", CultureInfo.CurrentCulture)} com taxa de {BankAccount.TransactionRate * 100:F2}% e taxa máxima de {BankAccount.MaxTransactionFee.ToString("C", CultureInfo.CurrentCulture)} é: {transactionFee.ToString("C", CultureInfo.CurrentCulture)}");

// Calcular taxa de cheque especial usando valores e taxas da classe BankAccount
double overdrawnAmount = 500;
double overdraftFee = AccountCalculations.CalculateOverdraftFee(overdrawnAmount, BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);
Console.WriteLine($"Taxa de cheque especial para uma conta com saldo negativo de {overdrawnAmount.ToString("C", CultureInfo.CurrentCulture)}, usando taxa de {BankAccount.OverdraftRate * 100:F2}% e taxa máxima de {BankAccount.MaxOverdraftFee.ToString("C", CultureInfo.CurrentCulture)} é: {overdraftFee.ToString("C", CultureInfo.CurrentCulture)}");

// Converter moeda
double originalCurrencyProvided = 100;
double currentExchangeRate = 1.2;
double foreignCurrencyReceived = AccountCalculations.ReturnForeignCurrency(originalCurrencyProvided, currentExchangeRate);
Console.WriteLine($"A moeda estrangeira recebida após trocar {originalCurrencyProvided.ToString("C", CultureInfo.CurrentCulture)} a uma taxa de câmbio de {currentExchangeRate:F2} é: {foreignCurrencyReceived.ToString("C", CultureInfo.CurrentCulture)}");

// Aplicar juros
Console.WriteLine("\nAplicando juros à Conta 1...");
double timePeriodYears = 30 / 365.0;    // calcular os juros acumulados nos últimos 30 dias
account1.ApplyInterest(timePeriodYears);
Console.WriteLine($"Conta 1 após aplicar juros: Saldo = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}, Taxa de juros = {BankAccount.InterestRate:P2}, Período = {timePeriodYears:F2} anos");

// Emitir cheque administrativo
Console.WriteLine("Emitindo cheque administrativo da conta 2...");
double checkAmount = 500;
bool receivedCashiersCheck = account2.IssueCashiersCheck(checkAmount);
Console.WriteLine($"Conta 2 após solicitar cheque administrativo: Recebeu cheque administrativo: {receivedCashiersCheck}, Saldo = {account2.Balance.ToString("C", CultureInfo.CurrentCulture)}, Valor da transação = {checkAmount.ToString("C", CultureInfo.CurrentCulture)}, Taxa de transação = {BankAccount.TransactionRate:P2}, Taxa máxima = {BankAccount.MaxTransactionFee.ToString("C", CultureInfo.CurrentCulture)}");

// Aplicar reembolso
Console.WriteLine("Aplicando reembolso à Conta 3...");
double refundAmount = 50;
account3.ApplyRefund(refundAmount);
Console.WriteLine($"Conta 3 após aplicar reembolso: Saldo = {account3.Balance.ToString("C", CultureInfo.CurrentCulture)}, Valor do reembolso = {refundAmount.ToString("C", CultureInfo.CurrentCulture)}");

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

// Passo 7: Demonstrar o uso de parâmetros nomeados e opcionais
Console.WriteLine("\nDemonstrando parâmetros nomeados e opcionais...");
string customerId = customer1.CustomerId;
double openingBalance = 1500;

// especifica apenas o ID do cliente e utiliza os parâmetros opcionais padrão (balance e accountType)
BankAccount account4 = new BankAccount(customerId);
Console.WriteLine(account4.DisplayAccountInfo());

// especifica o ID do cliente e o saldo inicial, usando o tipo de conta padrão
BankAccount account5 = new BankAccount(customer1.CustomerId, openingBalance);
Console.WriteLine(account5.DisplayAccountInfo());

// especifica o ID do cliente e utiliza um parâmetro nomeado para definir o tipo de conta
BankAccount account6 = new BankAccount(customer2.CustomerId, accountType: "Checking");
Console.WriteLine(account6.DisplayAccountInfo());

// utiliza parâmetros nomeados para especificar todos os parâmetros
BankAccount account7 = new BankAccount(accountType: "Checking", balance: 5000, customerIdNumber: customer2.CustomerId);
Console.WriteLine(account7.DisplayAccountInfo());

// Passo 8: Demonstrar o uso de inicializadores de objeto e construtores de cópia
Console.WriteLine("\nDemonstrando inicializadores de objeto e construtores de cópia...");

// Usando inicializador de objeto
BankCustomer customer4 = new BankCustomer("Mikaela", "Lee") { FirstName = "Mikaela", LastName = "Lee" };
Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.CustomerId}");

// Usando construtor de cópia
BankCustomer customer5 = new BankCustomer(customer4);
Console.WriteLine($"BankCustomer 5 (cópia do customer4): {customer5.FirstName} {customer5.LastName} {customer5.CustomerId}");

// Usando inicializador de objeto para conta
BankAccount account8 = new BankAccount(customer4.CustomerId) { AccountType = "Savings" };
Console.WriteLine($"Account 8: Conta # {account8.AccountNumber}, tipo {account8.AccountType}, saldo {account8.Balance}, taxa {BankAccount.InterestRate}, ID do cliente {account8.CustomerId}");

// Usando construtor de cópia para conta
BankAccount account9 = new BankAccount(account4);
Console.WriteLine($"Account 9 (cópia da account4): Conta # {account9.AccountNumber}, tipo {account9.AccountType}, saldo {account9.Balance}, taxa {BankAccount.InterestRate}, ID do cliente {account9.CustomerId}");
