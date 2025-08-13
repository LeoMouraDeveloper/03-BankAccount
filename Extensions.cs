using System;
namespace _03_Bank

{
    public static class BankCustomerExtensions
    {
        // Método de extensão para verificar se o ID do cliente é válido
        public static bool IsValidCustomerId(this BankCustomer customer)
        {
            return customer.CustomerId.Length == 10;
        }

        // Método de extensão para cumprimentar o cliente
        public static string GreetCustomer(this BankCustomer customer)
        {
            return $"Hello, {customer.ReturnFullName()}!";
        }
    }
    public static class BankAccountExtensions
    {
        // Método de extensão para verificar se a conta está com saldo negativo
        public static bool IsOverdrawn(this BankAccount account)
        {
            return account.Balance < 0;
        }

        // Método de extensão para verificar se um valor especificado pode ser sacado
        public static bool CanWithdraw(this BankAccount account, double amount)
        {
            return account.Balance >= amount;
        }
    }
}