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
        public Account checking = new Account ();
        public Account savings = new Account ();

        public StreamReader reader = new StreamReader ("accounts.csv");
        public CsvReader csvReader;

        public AccountManager ()
        {

            csvReader = new CsvReader (reader, CultureInfo.InvariantCulture);
            var import = csvReader.GetRecords<Account> ().ToList ();

            if (import.Count == 2)
            {
                checking = import[0];
                savings = import[1];
            }

        }
        public void ExportTransactions ()
        {
            StreamWriter writer = new StreamWriter ("accounts.csv");
            var csvWriter = new CsvWriter (writer, CultureInfo.InvariantCulture);
            var writable = new List<Account> () { checking, savings };
            csvWriter.WriteRecords (writable);
            writer.Flush ();
        }
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
            ExportTransactions ();
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
            ExportTransactions ();

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
            ExportTransactions ();
        }
    }
}