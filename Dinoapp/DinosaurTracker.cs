using System;
using System.Collections.Generic;
using System.Linq;
namespace Dinoapp {
    public class DinosaurTracker {
        public List<Dinosaur> Dinosaur { get; set; } = new List<Dinosaur> ();

        public void AddANewDinosaur (int where, string what, int weight, Diet diet) {
            var dinosaur = new Dinosaur {
                Name = what,
                EnclosureNumber = where,
                DateAcquired = DateTime.Now,
                DinoDiet = diet,
                DinoWeight = weight,
            };
            Dinosaur.Add (dinosaur);
        }
        public void RemoveDinosaur (string what) {

            var thingToRemove = Dinosaur.Where (dinosaur => dinosaur.Name == what).ToList ();
            if (thingToRemove.Count () > 1) {
                Console.WriteLine ($"I see you would like to remove a dinosaur. Which one would you like to remove?");
                for (int i = 0; i < thingToRemove.Count; i++) {
                    var extinct = thingToRemove[i];
                    Console.WriteLine ($"{i + 1}: {extinct.EnclosureNumber} at {extinct.DateAcquired}");
                }
                var index = int.Parse (Console.ReadLine ());
                Dinosaur.Remove (thingToRemove[index - 1]);
            } else {
                Dinosaur.Remove (thingToRemove.First ());
            }

        }
        //transfer dino
        public void TransferDinosaur (string what, int where) {
            var thingToTransfer = Dinosaur.Where (dinosaur => dinosaur.Name == what).ToList ();
            if (thingToTransfer.Count () > 1) {
                Console.WriteLine ($"I see you would like to transfer a dinosaur. Which one would you like to transfer?");
                for (int i = 0; i < thingToTransfer.Count; i++) {
                    var extinct = thingToTransfer[i];
                    Console.WriteLine ($"{i + 1}: {extinct.EnclosureNumber} at {extinct.DateAcquired}");
                }
                var index = int.Parse (Console.ReadLine ());
                var dino = thingToTransfer[index - 1];
                dino.EnclosureNumber = where;
            } else {
                var dino = thingToTransfer[0];
                dino.EnclosureNumber = where;
            }
        }

        public void GetHeaviestDinosaurs () {
            var sorted = Dinosaur.OrderByDescending (dino => dino.DinoWeight).ToList ();

            var topThreeHeaviest = sorted.Take (3).ToList ();
            Console.WriteLine ("The heaviest dinosaurs are:");
            for (var i = 0; i < topThreeHeaviest.Count; i++) {
                var dino = topThreeHeaviest[i];
                Console.WriteLine ($"{i + 1}: {dino.Name} at {dino.DinoWeight} lbs");
            }
        }

        public void GetDietStats () {
            var carnivores = Dinosaur.Where (dino => dino.DinoDiet == Diet.Carnivore);
            var herbivores = Dinosaur.Where (dino => dino.DinoDiet == Diet.Herbivore);

            Console.WriteLine ($"# of Herbivores: {herbivores.Count()}");
            Console.WriteLine ($"# of Carnivores: {carnivores.Count()}");
        }

    }
}