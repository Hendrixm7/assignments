using System;
using System.Collections.Generic;
using Rhythm.Models;

namespace Rhythm.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public string Length { get; set; }
        public string Genre { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}