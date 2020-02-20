using System;
using System.Collections.Generic;
namespace Dinoapp {
    public enum Diet {
        Herbivore = 1,
        Carnivore
    }
    public class Dinosaur {
        //Name
        public string Name { get; set; }

        //Diet Type
        public Diet DinoDiet { get; set; }

        //Default Date When Dino Is Acquired
        public DateTime DateAcquired { get; set; }

        //Dino Weight
        public int DinoWeight { get; set; }

        //Dino Enclosure Number
        public int EnclosureNumber { get; set; }

    }
}