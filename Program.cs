using System;
using System.Collections.Generic;
using System.Globalization;

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
                            Console.WriteLine("Please enter a Username:");
                            string userName = (Console.ReadLine()).ToLower();
                            Console.WriteLine("Please enter a Password:");
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
                                            Console.WriteLine("How much do you want to withdraw? (XX.XX)");
                                            decimal money;

                                            while (!Decimal.TryParse(Console.ReadLine(), out money))
                                            {
                                                Console.WriteLine("Please try again.");
                                            }
                                            money += 0.00m;
                                            _bankOOP.Withdraw(money * -1);
                                            Console.WriteLine("$" + money + " has been withdrawn from the account.");
                                            break;
                                        }
                                    case 'D':
                                        {
                                            Console.WriteLine("How much do you want to deposit? ($$.$$)");
                                            decimal money;

                                            while (!Decimal.TryParse(Console.ReadLine(), out money))
                                            {
                                                Console.WriteLine("You have entered an incorrect value. Please try again.");
                                            }
                                            money += 0.00m;
                                            _bankOOP.Deposit(money);
                                            Console.WriteLine("$" + money + " has been deposited to the account.");
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

                                            decimal money = _bankOOP.Balance();
                                            if (money < 0m)
                                            {
                                                Console.WriteLine("Total change to your account: ($" + Decimal.Negate(money) + ")");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Total change to your account: $" + money);
                                            }

                                            if ((customers[location].Balance + money) < 0m)
                                            {
                                                Console.WriteLine("Your current Balance is: ($" + Decimal.Negate(customers[location].Balance + money) + ")");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your current Balance is: $" + (customers[location].Balance + money));
                                            }

                                            Console.WriteLine(_bankOOP.ToString());
                                            customers[location].Balance += money;
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
