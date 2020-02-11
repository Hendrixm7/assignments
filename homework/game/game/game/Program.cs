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
      

      Random rnd = new Random();
      

      int mIndex = rnd.Next(userChoice.Length);
      Console.WriteLine("   userChoice:      {0}", userChoice);


      string[] computerChoice = { "Rock", "Paper", "Scissors" };   
      int fIndex = rnd.Next(computerChoice.Length);

      Console.WriteLine("   Computer Choice:   {0}", computerChoice[mIndex]); 

    
      


    } 

  }
}
