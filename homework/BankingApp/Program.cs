using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace BankingApp
{
  class Program
  {
    static void SaveAccounts (List<Account> accounts)
    {
      var writer = new StreamWriter ("accounts.csv");
      var csvWriter = new CsvWriter (writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords (accounts);
      writer.Flush ();

    }

    static void Main (string[] args)
    {
      var accountManager = new AccountManager ();
      Console.WriteLine ("Welcome to First Bank of Suncoast!");

      var accounts = new List<Account> ();

      var reader = new StreamReader ("accounts.csv");
      var csvReader = new CsvReader (reader, CultureInfo.InvariantCulture);
      accounts = csvReader.GetRecords<Account> ().ToList ();

      accountManager.DisplayAccount ();

      var isRunning = true;
      while (isRunning)
      {

        Console.WriteLine ("What would you like to do? (A)DD funds, (W)ITHDRAW funds, (T)RANSFER funds, or (Q)UIT the program?");
        var input = Console.ReadLine ().ToLower ();
        if (input == "a")
        {
          Console.WriteLine ("What account would you like to add to: Checking or Savings?");
          var add = Console.ReadLine ().ToLower ();
          Console.WriteLine ("What amount?");
          int amount = int.Parse (Console.ReadLine ());
          if (add == "checking")
          {
            accountManager.Adding (add, amount);

          }
          else if (add == "savings")
          {
            accountManager.Adding (add, amount);
          }
        }
        else if (input == "w")
        {
          Console.WriteLine ("What account would you like to withdraw from: Checking or Savings?");
          var withdrawal = Console.ReadLine ().ToLower ();
          Console.WriteLine ("How much?");
          int amount = int.Parse (Console.ReadLine ());
          if (withdrawal == "checking")
          {
            accountManager.Withdrawal (withdrawal, amount);

          }
          else if (withdrawal == "savings")
          {
            accountManager.Withdrawal (withdrawal, amount);

          }
        }
        else if (input == "t")
        {
          Console.WriteLine ("What account would you like to transfer to: Checking or Savings?");
          var transfer = Console.ReadLine ().ToLower ();
          Console.WriteLine ("How much?");
          int amount = int.Parse (Console.ReadLine ());
          if (transfer == "checking")
          {
            accountManager.Transfer (transfer, amount);

          }
          else if (transfer == "savings")
          {
            accountManager.Transfer (transfer, amount);
          }
        }
        else if (input == "q")
        {
          isRunning = false;
        }
        accountManager.DisplayAccount ();
      }
    }

  }
}