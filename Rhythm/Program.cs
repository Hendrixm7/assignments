using System;
using System.Collections.Generic;
using System.Linq;
using Rhythm.Models;

namespace Rhythm
{
  class Program
  {
    static void Main ()

    {
      Console.WriteLine ("Welcome to Rhythm");

      var db = new DatabaseContext ();
      var isRunning = true;
      while (isRunning)
      {

        Console.WriteLine ($"Which option do you choose: Add a band, View all, Produce an album, Remove a band, Resign a band, View albums, View songs, View signed bands, View unsigned bands, or quit?");
        var input = Console.ReadLine ().ToLower ();
        if (input == "quit")

        {
          isRunning = false;
        }
        else if (input == "add a band")
        {
          var newband = new Band ();

          Console.WriteLine ($"What band do you want to add?");
          newband.Name = Console.ReadLine ();
          Console.WriteLine ($"What country is the band from?");
          newband.CountryOfOrigin = Console.ReadLine ();
          Console.WriteLine ($"How many members are in the band?");
          newband.NumberOfMembers = Console.ReadLine ();
          Console.WriteLine ($"What is the band's website?");
          newband.Website = Console.ReadLine ();
          Console.WriteLine ($"What is the band's style?");
          newband.Style = Console.ReadLine ();
          Console.WriteLine ($"Who is the person to contact?");
          newband.PersonOfContact = Console.ReadLine ();
          Console.WriteLine ($"What is the contact phone number?");
          newband.ContactPhoneNumber = Console.ReadLine ();
          Console.WriteLine ($"Are they signed?");
          newband.IsSigned = bool.Parse (Console.ReadLine ());
          db.Bands.Add (newband);
          db.SaveChanges ();
        }
        else if (input == "view all")
        {
          var test = db.Bands.OrderBy (band => band.Name).ToList ();
          foreach (var band in test)
          {
            Console.WriteLine ($"{band.Name}");
          }
        }
        else if (input == "produce")
        {
          Console.WriteLine ($"What is the name of the album?");
          var albumName = Console.ReadLine ();

          var newAlbum = new Album () { Title = albumName };
          db.Albums.Add (newAlbum);

          Console.WriteLine ($"Let's add some songs");
          var addSongs = true;

          while (addSongs)
          {
            Console.WriteLine ($"What is the name of the song you want to add?");
            var songName = Console.ReadLine ();
            var newSong = new Song () { Title = songName };
            db.Songs.Add (newSong);
            newAlbum.Songs.Add (newSong);

            Console.WriteLine ($"Would you like to add another song?");
            var proceed = bool.Parse (Console.ReadLine ());
            addSongs = proceed;
          }

          Console.WriteLine ("What band does this album belong to?");
          var bandName = Console.ReadLine ();

          var bandEntity = db.Bands.First (band => band.Name == bandName);
          newAlbum.Band = bandEntity;
          db.SaveChanges ();
        }
        else if (input == "unsign")
        {
          Console.WriteLine ($"What band would you like to unsign?");
          var bandRemove = Console.ReadLine ();

          var bandEntity = db.Bands.First (band => band.Name == bandRemove);
          bandEntity.IsSigned = false;
          db.SaveChanges ();

        }
        else if (input == "resign")
        {
          Console.WriteLine ($"What band would you like to resign?");
          var bandRemove = Console.ReadLine ();

          var bandEntity = db.Bands.First (band => band.Name == bandRemove);
          bandEntity.IsSigned = true;
          db.SaveChanges ();

        }
        else if (input == "view album library")
        {
          Console.WriteLine ($"Which bands albums do you want to view?");
          var bandView = Console.ReadLine ();

          var bandEntity = db.Bands.First (band => band.Name == bandView);
          var albumEntities = db.Albums.Where (album => album.BandId == bandEntity.Id);

          foreach (var album in albumEntities)
          {

            Console.WriteLine (album.Title);
          }

        }
        else if (input == "view all albums")
        {
          var test = db.Albums.OrderBy (album => album.Title).ToList ();
          foreach (var album in test)
          {
            Console.WriteLine ($"{album.Title}");
          }

        }
        else if (input == "view a song")
        {
          Console.WriteLine ($"What song do you want to view?");
          var bandSong = Console.ReadLine ();
          var songEntity = db.Songs.First (song => song.Title == bandSong);
          var albumEntity = db.Albums.First (album => album.ID == songEntity.AlbumId);

          Console.WriteLine ($"{songEntity.Title} is in {albumEntity.Title}");
        }
        else if (input == "view all signed bands")
        {
          var signedBands = db.Bands.Where (band => band.IsSigned);
          foreach (var band in signedBands)
          {
            Console.WriteLine (band.Name);
          }

        }
        else if (input == "view all unsigned bands")
        {
          var unsignedBands = db.Bands.Where (band => !band.IsSigned);
          foreach (var band in unsignedBands)
          {
            Console.WriteLine (band.Name);
          }

        }
      }
    }
  }
}