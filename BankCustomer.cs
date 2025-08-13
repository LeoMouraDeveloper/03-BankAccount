using System;
namespace _03_Bank

{
    public class BankCustomer
    {
        private static int s_nextCustomerId;
        private string _firstName = "Tim";
        private string _lastName = "Shao";

        public readonly string CustomerId;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        static BankCustomer()
        {
            Random random = new Random();
            s_nextCustomerId = random.Next(10000000, 20000000);
        }

        public BankCustomer()
        {
            this.CustomerId = (s_nextCustomerId++).ToString("D10");
        }

        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = (s_nextCustomerId++).ToString("D10");
        }

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