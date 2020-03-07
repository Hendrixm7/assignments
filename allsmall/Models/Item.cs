using System;
using System.Collections.Generic;
using allsmall.Models;
using Microsoft.EntityFrameworkCore;

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
        public List<Item> Items { get; set; } = new List<Item> ();
    }

}