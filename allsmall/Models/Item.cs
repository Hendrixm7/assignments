using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using allsmall.Models;

namespace allsmall.Models
{
    public class Item
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }
        public int Price { get; set; }
        public DateTime DateOrdered { get; set; } = DateTime.Now;
        public int LocationId { get; set; }

        [JsonIgnore]
        public Location Location { get; set; }

    }

}