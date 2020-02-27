using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PartyThyme
{
  public class Program
  {
    static void Main (string[] args)
    {

      var db = new PlantContext ();

      var isRunning = true;
      while (isRunning)
      {
        Console.WriteLine ("Commands: add, remove, water, location, view all, needs water, or quit?");
        var input = Console.ReadLine ().ToLower ();
        if (input == "quit")
        {
          isRunning = false;
        }
        else if (input == "add")
        {
          var newplant = new Plant ();

          Console.WriteLine ($"What is your plant's species?");
          newplant.Species = Console.ReadLine ();
          Console.WriteLine ($"Where is your plant located?");
          newplant.LocatedPlant = Console.ReadLine ();
          Console.WriteLine ($"How much light does your plant need?");
          newplant.LightNeeded = Console.ReadLine ();
          db.Plants.Add (newplant);
          db.SaveChanges ();
        }
        else if (input == "view all")
        {
          var test = db.Plants.OrderBy (plant => plant.LocatedPlant).ToList ();
          foreach (var plant in test)
          {
            Console.WriteLine ($"{plant.Species} is located in {plant.LocatedPlant}");
          }

        }
        else if (input == "remove")
        {
          Console.WriteLine ($"Which plant would you like to remove?");
          var userRemove = int.Parse (Console.ReadLine ());

          var plantToDelete = db.Plants.First (p => p.Id == userRemove);
          db.Plants.Remove (plantToDelete);
          db.SaveChanges ();
        }
        else if (input == "water")
        {
          Console.WriteLine ("Which plant would you like to water?");
          var plantToWaterId = int.Parse (Console.ReadLine ());
          var plantToUpdate = db.Plants.First (p => p.Id == plantToWaterId);
          plantToUpdate.LastWateredDate = DateTime.Now;
          db.SaveChanges ();

        }
        else if (input == "location")
        {
          Console.WriteLine ("What location is your plant in?");
          var plantLocation = Console.ReadLine ();
          var plantPlace = db.Plants.Where (p => p.LocatedPlant == plantLocation).ToList ();
          foreach (var plant in plantPlace)
          {
            Console.WriteLine ($"{plant.Species} is in {plantLocation}");
          }
        }
        else if (input == "needs water")
        {
          var needsWatering = db.Plants.Where (p => p.LastWateredDate < DateTime.Today).ToList ();
          foreach (var plant in needsWatering)
          {
            Console.WriteLine ($"{plant.Species} needs watering!");
          }

        }

      }

    }
  }
}