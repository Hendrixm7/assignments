using System;
using System.Collections.Generic;
namespace Dinoapp {

  class Program {
    static void Main (string[] arg) {
      Console.WriteLine ("Welcome to Dinosaur Tracker!");
      Console.WriteLine ("Here are your current dinosaurs!");
      var tracker = new DinosaurTracker ();

      var isRunning = true;
      while (isRunning) {

        foreach (var d in tracker.Dinosaur) {
          Console.WriteLine ($"{d.Name} at {d.DinoDiet} at {d.DateAcquired}");
        }

        Console.WriteLine ("How do you want to manage your dino's?");
        Console.WriteLine ("(ADD), (REMOVE), (TRANSFER), (STATS), (HEAVIEST), or (QUIT)");
        var input = Console.ReadLine ().ToLower ();
        if (input == "add") {
          Console.WriteLine ("What dino do you want to add? ");
          var what = Console.ReadLine ();
          Console.WriteLine ("How much does this dino weigh?");
          var weight = int.Parse (Console.ReadLine ());
          Console.WriteLine ("What does this dino eat?");
          Console.WriteLine ("Type 1 for Herbivore and 2 for Carnivore");
          var snacks = (Diet) int.Parse (Console.ReadLine ());
          Console.WriteLine ("What enclosure are you adding your dino to? ");
          var where = int.Parse (Console.ReadLine ());

          tracker.AddANewDinosaur (where, what, weight, snacks);
        } else if (input == "remove") {
          Console.WriteLine ("What dino do you want remove?");
          var dinosaur = Console.ReadLine ();
          tracker.RemoveDinosaur (dinosaur);
        } else if (input == "quit") {
          isRunning = false;
        } else if (input == "transfer") {
          Console.WriteLine ("What dino do you want to transfer?");
          var dinosaurs = Console.ReadLine ();
          Console.WriteLine ("What enclosure is your dino moving to?");
          var enclosure = int.Parse (Console.ReadLine ());
          tracker.TransferDinosaur (dinosaurs, enclosure);
        } else if (input == "stats") {
          tracker.GetDietStats ();
        } else if (input == "heaviest") {
          tracker.GetHeaviestDinosaurs ();
        }
      }

    }

  }

}