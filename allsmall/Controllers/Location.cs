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
    public class LocationController : ControllerBase

    {
        public DatabaseContext db { get; set; } = new DatabaseContext ();
        [HttpGet]
        public List<Location> GetAllLocations ()
        {
            var Locations = db.Locations.OrderBy (m => m.Id);
            return Locations.ToList ();
        }

        [HttpPost ("add")]
        public Location AddLocation (Location location)
        {
            db.Locations.Add (location);
            db.SaveChanges ();
            return location;
        }

    }
}