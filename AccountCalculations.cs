using System;

namespace _03_Bank
{
    public static class AccountCalculations
    {
        // Método para calcular juros compostos
        public static double CalculateCompoundInterest(double principal, double annualRate, double years)
        {
            return principal * Math.Pow(1 + annualRate, years) - principal;
        }

        // Método para validar número da conta (deve ter 8 dígitos)
        public static bool ValidateAccountNumber(int accountNumber)
        {
            return accountNumber.ToString().Length == 8;
        }

        // Método para calcular a taxa de transação (ex.: transferências ou cheques administrativos)
        public static double CalculateTransactionFee(double amount, double transactionRate, double maxTransactionFee)
        {
            // Calcula a taxa baseada na porcentagem da transação
            double fee = amount * transactionRate;

            // Retorna o menor valor entre a taxa calculada e a taxa máxima permitida
            return Math.Min(fee, maxTransactionFee);
        }

        // Método para calcular a taxa de cheque especial (overdraft)
        public static double CalculateOverdraftFee(double amountOverdrawn, double overdraftRate, double maxOverdraftFee)
        {
            // Calcula a taxa baseada no valor negativo da conta
            double fee = amountOverdrawn * overdraftRate;

            // Retorna o menor valor entre a taxa calculada e a taxa máxima de cheque especial
            return Math.Min(fee, maxOverdraftFee);
        }

        // Método para calcular o valor convertido de moeda estrangeira
        public static double ReturnForeignCurrency(double amount, double exchangeRate)
        {
            return amount * exchangeRate;
        }
    }
}
