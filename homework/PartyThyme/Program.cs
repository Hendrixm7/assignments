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

      var newplant = new Plant ();
      Console.WriteLine ("Welcome to Party Thyme!");
      Console.WriteLine ($"What is your plant's species?");
      newplant.Species = Console.ReadLine ();
      Console.WriteLine ($"Where is your plant located?");
      newplant.LocatedPlant = Console.ReadLine ();
      Console.WriteLine ($"How much light does your plant need?");
      newplant.LightNeeded = Console.ReadLine ();
      db.Plants.Add (newplant);
      db.SaveChanges ();
      var test = db.Plants.OrderBy (plant => plant.LocatedPlant).ToList ();
      foreach (var plant in test)
      {
        Console.WriteLine ($"{plant.Species} is located in {plant.LocatedPlant}");
      }

      Console.WriteLine ($"Which plant would you like to remove?");
      var userRemove = int.Parse (Console.ReadLine ());

      var plantToDelete = db.Plants.First (p => p.Id == userRemove);
      db.Plants.Remove (plantToDelete);
      db.SaveChanges ();

      Console.WriteLine ("Which plant would you like to water?");
      var plantToWaterId = int.Parse (Console.ReadLine ());
      var plantToUpdate = db.Plants.First (p => p.Id == plantToWaterId);
      plantToUpdate.LastWateredDate = DateTime.Now;
      db.SaveChanges ();

      var needsWatering = db.Plants.Where (p => p.LastWateredDate < DateTime.Today).ToList ();
      foreach (var plant in needsWatering)
      {
        Console.WriteLine ($"{plant.Species} needs watering!");
      }
      Console.WriteLine ("What location is your plant in?");
      var plantLocation = Console.ReadLine ();
      var plantPlace = db.Plants.Where (p => p.LocatedPlant == plantLocation).ToList ();
      foreach (var plant in plantPlace)
      {
        Console.WriteLine ($"{plant.Species} is in {plantLocation}");
      }

    }
  }
}