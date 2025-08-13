using System;

namespace _03_Bank
{
    public partial class BankCustomer
    {
        //Metodo que retorna o nome Completo do cliente
        public string ReturnFullName()
        {
            return $"{FirstName} {LastName}";
        }

        //Método que atualiza o nome do cliente
        public void UpdateCustomerName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //Método que exibe informações do cliente
        public string DisplayCustomerInfo()
        {
            return $"Customer ID: {CustomerId}\nName: {ReturnFullName()}";
        }
    }
}