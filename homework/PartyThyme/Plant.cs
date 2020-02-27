using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PartyThyme
{

    public class Plant
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string LocatedPlant { get; set; }
        public DateTime PlantDate { get; set; } = DateTime.Now;
        public DateTime LastWateredDate { get; set; } = DateTime.Now;
        public string LightNeeded { get; set; }

        public string WaterNeeded { get; set; }

    }

}