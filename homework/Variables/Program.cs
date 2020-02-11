using System;

namespace Variables {
  class Program {
    static void Main (string[] args) {
      int numberOfCupsOfCoffee = 1;
      string myFullName = "Michelle Hendrix";
      string today = "February 10, 2020";
      Console.WriteLine (numberOfCupsOfCoffee + " " + myFullName + " " + today);

      Console.WriteLine ("Enter Your Name: ");
      string user = Console.ReadLine ();

      Console.WriteLine ("Welcome to " + user + "!");

      // Input numbers
      Console.WriteLine ("You will be asked to input 2 numbers.");
      Console.WriteLine ("Input your first number: ");
      string operandOneRaw = Console.ReadLine ();

      Console.WriteLine ("Input your second number: ");
      string operandTwoRaw = Console.ReadLine ();

      double operand1 = double.Parse (operandOneRaw);
      double operand2 = double.Parse (operandTwoRaw);

      double sum = operand1 + operand2;
      double difference = operand1 - operand2;
      double quotient = operand1 / operand2;
      double product = operand1 * operand2;
      double remainder = operand1 % operand2;

      Console.WriteLine ("Your numbers were " + operand1 + " and " + operand2 + ".");
      Console.WriteLine ("SUM: " + sum);
      Console.WriteLine ("DIFFERENCE: " + difference);
      Console.WriteLine ("QUOTIENT: " + quotient);
      Console.WriteLine ("PRODUCT: " + product);
      Console.WriteLine ("REMAINDER: " + remainder);
    }
  }
}