using System;
namespace _03_Bank
{
    public class BankAccount
    {
        private static int s_nextAccountNumber = 1;
        public int AccountNumber { get; }
        public double Balance { get; private set; } = 0;
        public static double InterestRate;
        public string AccountType { get; set; } = "Checking";
        public string CustomerId { get; }

        static BankAccount()
        {
            Random random = new Random();
            s_nextAccountNumber = random.Next(10000000, 20000000);
            InterestRate = 0;
        }

        public BankAccount(string customerIdNumber)
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
        }
        public BankAccount(string customerIDNumber, double balance, string accountType)
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIDNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }

        //Método que insere dinheiro na conta (deposito)
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        //Método que retira dinheiro da conta (saque)
        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        //Método que transfire dinheiro para outra conta (transferência)
        public bool Transfer(BankAccount destinationAccount, double amount)
        {
            if (Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                return true;
            }
            return false;
        }

        //Método que aplique juros ao saldo da conta (rendimento)
        public void ApplyInterest()
        {
            Balance += Balance * InterestRate;
        }

        //Método que exiba informações da conta
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
        }

    }
}