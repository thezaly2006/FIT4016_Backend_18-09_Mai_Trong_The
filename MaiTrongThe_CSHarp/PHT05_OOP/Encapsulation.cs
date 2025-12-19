using System;

namespace Encapsulation
{
    class BankAccount
    {
        private double _balance;

        public double Balance
        {
            get { return _balance; }
        }

        public BankAccount(double initialBalance)
        {
            if (initialBalance >= 0)
                _balance = initialBalance;
            else
                _balance = 0;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine("Gui tien thanh cong: " + amount);
            }
            else
            {
                Console.WriteLine("So tien gui khong hop le");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("So tien rut khong hop le");
            }
            else if (amount > _balance)
            {
                Console.WriteLine("So du khong du");
            }
            else
            {
                _balance -= amount;
                Console.WriteLine("Rut tien thanh cong: " + amount);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(1000);

            Console.WriteLine("So du hien tai: " + account.Balance);

            account.Deposit(500);
            Console.WriteLine("So du hien tai: " + account.Balance);

            account.Withdraw(300);
            Console.WriteLine("So du hien tai: " + account.Balance);

            account.Withdraw(2000);

            Console.ReadLine();
        }
    }
}