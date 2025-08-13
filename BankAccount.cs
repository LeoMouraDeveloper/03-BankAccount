namespace  _03_Bank
{
    public class BankAccount
    {
        private static int s_nextAccountNumber = 1;
        public readonly int AccountNumber;
        public double Balance = 0;
        public static double InterestRate;
        public string AccountType = "Checking";
        public readonly string CustomerId;

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

    }
}