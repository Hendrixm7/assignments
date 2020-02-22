using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
namespace BankingApp
{

    public class AccountManager
    {
        // public List<Account> accounts { get; set; } = new List<Account> ();
        public Account checking = new Account ();
        public Account savings = new Account ();

        public void DisplayAccount ()
        {
            Console.WriteLine ($"You have {checking.Amount} in your checking account.");
            Console.WriteLine ($"You have {savings.Amount} in your savings account.");
        }
        public void Adding (string accountType, int amount)
        {

            if (accountType == "checking")

            {

                checking.Amount += amount;

            }
            else if (accountType == "savings")
            {

                savings.Amount += amount;

            }
        }
        public void Withdrawal (string accountType, int amount)
        {

            if (accountType == "checking")

            {

                checking.Amount -= amount;

            }
            else if (accountType == "savings")
            {

                savings.Amount -= amount;

            }

        }
        public void Transfer (string accountType, int amount)
        {

            if (accountType == "checking")

            {

                savings.Amount -= amount;
                checking.Amount += amount;

            }
            else if (accountType == "savings")
            {

                savings.Amount += amount;
                checking.Amount -= amount;

            }

        }
    }
}