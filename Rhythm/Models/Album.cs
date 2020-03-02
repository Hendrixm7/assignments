using System;
using System.Collections.Generic;
using Rhythm.Models;

namespace Rhythm.Models

{

}

public class Album
{
    public int ID { get; set; }
    public string Title { get; set; }

    public bool IsExplicit { get; set; } = true;
    public DateTime ReleaseDate { get; set; }

    public int BandId { get; set; }
    public Band Band { get; set; }

    // Navigation properties
    public List<Song> Songs { get; set; } = new List<Song> ();

}