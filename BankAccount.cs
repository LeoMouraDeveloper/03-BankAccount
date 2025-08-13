using System;
namespace _03_Bank
{
    public class BankAccount
    {
        private static int s_nextAccountNumber = 1;
        public int AccountNumber { get; }
        public double Balance { get; private set; } = 0;
        public static double InterestRate { get; private set; }
        public static double TransactionRate { get; private set; }
        public static double MaxTransactionFee { get; private set; }
        public static double OverdraftRate { get; private set; }
        public static double MaxOverdraftFee { get; private set; }
        public string AccountType { get; set; } = "Checking";
        public string CustomerId { get; }

// Construtor estático: inicializa valores padrão da classe BankAccount
        static BankAccount()
        {
            Random random = new Random();
            s_nextAccountNumber = random.Next(10000000, 20000000);
            InterestRate = 0.00; // Taxa de juros padrão para contas correntes
            TransactionRate = 0.01; // Taxa de transação padrão para transferências e cheques administrativos
            MaxTransactionFee = 10; // Taxa máxima de transação para transferências e cheques administrativos
            OverdraftRate = 0.05; // Taxa de penalidade padrão para contas com saldo negativo
            MaxOverdraftFee = 10; // Taxa máxima de cheque especial
        }

        // Construtor com apenas o ID do cliente
        public BankAccount(string customerIdNumber)
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
        }

        // Construtor com parâmetros opcionais: saldo inicial e tipo de conta
        public BankAccount(string customerIdNumber, double balance = 200, string accountType = "Checking")
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }

        // Método para depositar dinheiro na conta
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        // Método para sacar dinheiro da conta
        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        // Método para transferir dinheiro para outra conta
        public bool Transfer(BankAccount destinationAccount, double amount)
        {
            if (Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                return true;
            }
            return false;
        }

        // Método para aplicar juros ao saldo da conta
        public void ApplyInterest(double years)
        {
            Balance += AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
        }

        // Método para emitir um cheque administrativo
        public bool IssueCashiersCheck(double amount)
        {
            if (amount > 0 && Balance >= amount + BankAccount.MaxTransactionFee)
            {
                Balance -= amount;
                Balance -= AccountCalculations.CalculateTransactionFee(amount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
                return true;
            }
            return false;
        }

        // Método para aplicar reembolso na conta
        public void ApplyRefund(double refund)
        {
            Balance += refund;
        }

        // Método que retorna informações da conta formatadas
        public string DisplayAccountInfo()
        {
            return $"Número da Conta: {AccountNumber}, Tipo: {AccountType}, Saldo: {Balance}, Taxa de Juros: {InterestRate}, ID do Cliente: {CustomerId}";
        }

        // Construtor de cópia: cria uma nova conta copiando os dados de uma conta existente
        public BankAccount(BankAccount existingAccount)
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = existingAccount.CustomerId;
            this.Balance = existingAccount.Balance;
            this.AccountType = existingAccount.AccountType;
        }
    }
}