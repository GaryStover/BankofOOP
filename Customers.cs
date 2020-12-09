using System;
using System.Collections.Generic;
using System.Text;

namespace BankofOOP
{
    class Customers
    {
        string _userName;
        string _password;
        string _customer;
        decimal _balance;
                
        public Customers(string userName, string password, string customer, decimal balance)
        {
            this._userName = userName;
            this._password = password;
            this._customer = customer;
            this._balance = balance;
        }

        public string UserName { get { return _userName; } }

        public string Password { get { return _password; } }

        public string Customer { get { return _customer; } }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

    }
}
    
