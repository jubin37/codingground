using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankatm
{
    class Program
    {
        public void login()
        {
            int userpin;
            Console.Beep(500, 500);

            Console.WriteLine("**********Welcome to ACE Bank**********");
            do
            {
                Console.WriteLine("Please enter your 4 digit ATM pin.");
                userpin = Convert.ToInt32(Console.ReadLine());
                if (userpin != 1234)
                {
                    Console.WriteLine("Invaid Pin");
                }
            }
            while (userpin != 1234);
            Console.WriteLine("Pin Accepted");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.login();
            Banktrans bt = new Banktrans();
            bt.trans();
        }
    }
    class Banktrans
    {
        private int _amount = 10000;
        private int _deposit;
        private int _withdraw;
        int choice;
        string userinput;

        public int Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }
        public int Withdraw
        {
            get { return _withdraw; }
            set { _withdraw = value; }
        }
        public void trans()
        {
            do
            {
                Console.WriteLine("**********Welcome to ATM Service**********");
                Console.WriteLine("Your current balance is {0}", this._amount);
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw Cash");
                Console.WriteLine("3. Deposit Cash");
                Console.WriteLine("4. Quit");
                Console.WriteLine("Please enter your choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your balance is {0}", _amount);
                        break;
                    case 2:
                        Console.WriteLine("Enter the amount to withdraw:");
                        Withdraw = int.Parse(Console.ReadLine());
                        if (Withdraw % 100 != 0)
                        {
                            Console.WriteLine("Please enter the amount in multiples of 100");
                        }
                        else if (Withdraw > _amount)
                        {
                            Console.WriteLine("Insufficient balance");
                            Console.WriteLine("Your transaction is not sucessfull");
                            Console.WriteLine("Your current balance is {0}", _amount);
                        }
                        else
                        {
                            _amount -= Withdraw;
                            Console.WriteLine("Your transaction is sucessfull");
                            Console.WriteLine("Please collect cash");
                            Console.WriteLine("Your current balance is {0}", _amount);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the amount to deposit");
                        Deposit = int.Parse(Console.ReadLine());
                        _amount += Deposit;
                        Console.WriteLine("Your balance is {0}", _amount);
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using ATM");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                } do
                {
                    Console.WriteLine("Do you wish to continue? Yes or No");
                    userinput = Console.ReadLine().ToUpper();
                    if (userinput != "YES" && userinput != "NO")
                    {
                        Console.WriteLine("Invalid reponse");
                    }
                } while (userinput != "YES" && userinput != "NO");
            } while (userinput == "YES");
            Console.WriteLine("Thank you for using ACE ATM");
            Console.ReadLine();
        }
    }
}