using System;

namespace _03_Bank
{
    public partial class BankCustomer
    {
        private static int s_nextCustomerId; // Contador estático para gerar IDs únicos de clientes
        private string _firstName = "Tim";   // Primeiro nome padrão
        private string _lastName = "Shao";   // Sobrenome padrão

        public readonly string CustomerId;   // ID único do cliente (somente leitura)

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

        // Construtor estático: executado apenas uma vez para inicializar o ID do cliente
        static BankCustomer()
        {
            Random random = new Random();
            s_nextCustomerId = random.Next(10000000, 20000000); // Gera ID inicial aleatório
        }

        // Construtor principal para criar um novo cliente
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = (s_nextCustomerId++).ToString("D10"); // ID com 10 dígitos
        }

        // Construtor de cópia: cria um novo cliente copiando informações de um cliente existente
        public BankCustomer(BankCustomer existingCustomer)
        {
            this.FirstName = existingCustomer.FirstName; 
            this.LastName = existingCustomer.LastName;
            // Gera um novo ID único para o cliente copiado
            this.CustomerId = (s_nextCustomerId++).ToString("D10");
        }
    }
}
