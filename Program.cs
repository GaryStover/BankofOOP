using System;
using System.Collections.Generic;
using System.Globalization;


//Program by Gary Stover. Code referenced and used from Murachs C# 2015, https://stackoverflow.com/, Essential C# 7.0 Sixth Edition, https://learning.oreilly.com/, https://docs.microsoft.com/en-us/dotnet/csharp/


namespace BankofOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customers> customers = new List<Customers>();
            BankOOP account = new BankOOP();
            char selection = 'Z';
            Console.WriteLine("Welcome to OOP Bank.\nPlease Log in.\n");

            Customers customer = new Customers("efudd", "efudd1", "Elmer Fudd", 345M);
            customers.Add(customer);
            customer = new Customers("bbunny", "bbunny1", "Bugs Bunny", 1722.99M);
            customers.Add(customer);
            customer = new Customers("tbird", "tbird1", "Tweety Bird", 45.44M);
            customers.Add(customer);

            while (selection != 'Q')
            {
                Console.WriteLine("(L)ogin\n(Q)uit\n");
                selection = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (char.ToUpper(selection))
                {
                    case 'L':
                        {
                            Console.WriteLine("Enter a Username:");
                            string userName = (Console.ReadLine()).ToLower();
                            Console.WriteLine("Enter a Password:");
                            string password = Console.ReadLine();

                            int _selection = account.Login(customers, userName, password);

                            if (_selection > -1)
                            {
                                Logged(account, customers, _selection);
                                Console.WriteLine("How may we help you?");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Credentals. Please try again.\n");
                            }

                            break;
                        }
                    case 'Q':
                        {
                            Console.Clear();
                            Console.WriteLine("Thank you for using OOP Bank, have a wonderful day.");
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You have selected an incorrect option.");
                            break;
                        }

                        static void Logged(BankOOP _bankOOP, List<Customers> customers, int location)
                        {
                            char selection = 'Z';
                            Console.WriteLine("\nWelcome " + customers[location].Customer + ", How may we help you?\n");

                            while (selection != 'L')
                            {
                                Console.WriteLine("(W)ithdraw\n(D)eposit\n(B)alance\n(L)ogout\n");
                                selection = Console.ReadKey(true).KeyChar;
                                Console.Clear();

                                switch (char.ToUpper(selection))
                                {
                                    case 'W':
                                        {
                                            Console.WriteLine("How much do you want to withdraw? ($$.$$)");
                                            decimal dollars;

                                            while (!Decimal.TryParse(Console.ReadLine(), out dollars))
                                            {
                                                Console.WriteLine("Please try again.");
                                            }
                                            dollars += 0.00m;
                                            _bankOOP.Withdraw(dollars * -1);
                                            Console.WriteLine("$" + dollars + " has been withdrawn from the account.");
                                            break;
                                        }
                                    case 'D':
                                        {
                                            Console.WriteLine("How much do you want to deposit? ($$.$$)");
                                            decimal _dollars;

                                            while (!Decimal.TryParse(Console.ReadLine(), out _dollars))
                                            {
                                                Console.WriteLine("You have entered an incorrect value. Please try again.");
                                            }
                                            _dollars += 0.00m;
                                            _bankOOP.Deposit(_dollars);
                                            Console.WriteLine("$" + _dollars + " has been deposited to the account.");
                                            break;
                                        }
                                    case 'B':
                                        {
                                            Console.WriteLine("Your current balance is $" + (customers[location].Balance + _bankOOP.Balance()) + "\n");
                                            break;
                                        }
                                    case 'L':
                                        {
                                            selection = 'L';

                                            decimal dollars = _bankOOP.Balance();
                                            if (dollars < 0m)
                                            {
                                                Console.WriteLine("Total change to your account: ($" + Decimal.Negate(dollars) + ")");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Total change to your account: $" + dollars);
                                            }

                                            if ((customers[location].Balance + dollars) < 0m)
                                            {
                                                Console.WriteLine("Your current Balance is: ($" + Decimal.Negate(customers[location].Balance + dollars) + ")");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your current Balance is: $" + (customers[location].Balance + dollars));
                                            }

                                            Console.WriteLine(_bankOOP.ToString());
                                            customers[location].Balance += dollars;
                                            _bankOOP.Logout();
                                            break;
                                        }

                                }        
                               
                            }
                        }
                }
            }
        }
    }
}
