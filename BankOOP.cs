using System;
using System.Collections.Generic;
using System.Text;

namespace BankofOOP
{
    class BankOOP
    {
        List<string> transactionsList = new List<string>();
        List<decimal> amountsList = new List<decimal>();

        public int Login(List<Customers> customer, string userName, string password)
        {
            int myList = -1;
            for (int i = 0; i < customer.Count; i++)
            {
                if ((customer[i].UserName).ToLower() == userName && customer[i].Password == password)
                {
                    myList = i;
                }
            }
            return myList;
        }
        public void Withdraw(decimal dollars)
        {

            transactionsList.Add("Withdraw");
            amountsList.Add(dollars);

        }

        public void Deposit(decimal dollars)
        {

            transactionsList.Add("Deposit");
            amountsList.Add(dollars);

        }

        public decimal Balance()
        {
            if (amountsList.Count <= 0)
            {
                return 0m;
            }
            else
            {
                decimal changes = 0m;
                foreach (decimal item in amountsList)
                {
                    changes += item;
                }
                return changes;
            }
        }

        public void Logout()
        {
            transactionsList = new List<string>();
            amountsList = new List<decimal>();
        }

        public override string ToString()
        {
            string transaction = "";
            for (int i = 0; i < transactionsList.Count; i++)
            {
                if (transactionsList[i] == "Withdraw")
                {
                    amountsList[i] = Decimal.Negate(amountsList[i]);
                }
                transaction += transactionsList[i] + ":\t$" + amountsList[i] + "\n";
            }
            return transaction;
        }

    }
}