using System;

namespace Game
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to The Game Rock Paper Scissors!");
      Console.WriteLine("You may choose Rock, Paper, or Scissors.");
      Console.WriteLine("Please choose an option!");
      var userChoice = Console.ReadLine();
      

      
      Console.WriteLine("   userChoice:      {0}", userChoice);


      Random rnd = new Random();
      string[] computerChoices = { "Rock", "Paper", "Scissors" };   
      int fIndex = rnd.Next(computerChoices.Length);
      var computerChoice = computerChoices[fIndex];

      Console.WriteLine("   Computer Choice:   {0}", computerChoice); 

  
      if (userChoice == "Rock" && computerChoice == "Rock") {
        Console.WriteLine("It was a tie!");
      }
      
      if (userChoice == "Rock" && computerChoice == "Scissors") { 
        Console.WriteLine("You Win!!");
      }

      if (userChoice == "Paper" && computerChoice == "Paper") {
        Console.WriteLine("It was a tie!");
      }

      if (userChoice == "Paper" && computerChoice == "Rock") {
        Console.WriteLine("You Win!!");
      }
      if (userChoice == "Scissors" && computerChoice == "Rock") {
        Console.WriteLine("Computer Wins!");
      }

      if (userChoice == "Paper" && computerChoice == "Scissors") {
        Console.WriteLine("Computer Wins!");
      }

      if (userChoice == "Scissors" && computerChoice == "Paper") {
        Console.WriteLine("You Win!!");
      }

      if (userChoice == "Scissors" && computerChoice == "Scissors") {
        Console.WriteLine("It was a tie!");
      }
        
      


    } 

  }
}
