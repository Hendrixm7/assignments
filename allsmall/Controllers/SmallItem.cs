using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using allsmall.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace allsmall.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext ();

        [HttpGet]
        public List<Item> GetAllItems ()
        {
            var Items = db.Items.OrderBy (m => m.Name);
            return Items.ToList ();
        }

        [HttpGet ("{id}")]
        public ActionResult<Item> GetOneItem (int id)
        {
            var item = db.Items.FirstOrDefault (i => i.ID == id);
            if (item == null)
            {
                return NotFound ();
            }
            return Ok (item);
        }

        [HttpPost ("add")]
        public Item AddItem (Item item)
        {
            db.Items.Add (item);
            db.SaveChanges ();
            return item;

        }

        [HttpPut ("{id}")]
        public Item UpdateOneItem (int id, Item newData)
        {
            newData.ID = id;
            db.Entry (newData).State = EntityState.Modified;
            db.SaveChanges ();
            return newData;
        }

        [HttpGet ("out-of-stock")]
        public List<Item> OutOfStock ()
        {
            var items = db.Items.Where (i => i.NumberInStock == 0).ToList ();
            return items;
        }

        [HttpDelete ("{id}")]
        public ActionResult DeleteOne (int id)
        {
            var item = db.Items.FirstOrDefault (f => f.ID == id);
            if (item == null)
            {
                return NotFound ();
            }
            db.Items.Remove (item);
            db.SaveChanges ();
            return Ok ();

        }

        [HttpGet ("search")]
        public Item Search ([FromQuery] string sku)
        {
            var item = db.Items.FirstOrDefault (i => i.SKU == sku.ToString ());
            return item;
        }
    }

}