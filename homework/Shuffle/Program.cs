using System;
using System.Collections.Generic;

namespace Shuffle {
  class Program {
    static void Main (string[] args) {
      var deckSuit = new List<string> () { "Hearts", "Diamonds", "Spades", "Clubs" };
      var deckFace = new List<string> () { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      var deck = new List<string> ();

      // Fill/create deck
      for (var i = 0; i < deckSuit.Count; i++) {
        for (var j = 0; j < deckFace.Count; j++) {
          var card = ($"{deckFace[j]} of {deckSuit[i]}");
          deck.Add (card);
        }
      }

      var rnd = new Random ();

      // Shuffle
      //
      // for i from n - 1 down to 1 do:
      for (int cardIndex = deck.Count - 1; cardIndex >= 1; cardIndex--) {
        //    j = random integer (where 0 <= j <= cardIndex)
        var randomIndex = rnd.Next (cardIndex);

        //    swap deck[cardIndex] with deck[randomIndex]
        var cardAtCardIndex = deck[cardIndex];
        var cardAtRandomIndex = deck[randomIndex];

        deck[cardIndex] = cardAtRandomIndex;
        deck[randomIndex] = cardAtCardIndex;
      }

      // Display all cards
      for (int cardIndex = 0; cardIndex < deck.Count; cardIndex++) {
        var card = deck[cardIndex];
        Console.WriteLine (card);
      }

      Console.WriteLine ("---- Explorer Mode ----");
      // Explorer Mode
      bool isPlaying = true;
      int idx = 0;
      while (isPlaying) {
        var card = deck[idx];
        Console.WriteLine (card);

        // You've already played a round
        Console.WriteLine ("Do you still want to play?");
        Console.WriteLine ("Enter y/n: ");

        string response = Console.ReadLine ();

        while (response != "n" && response != "y") {
          Console.WriteLine ("That is not a valid response. Please try again.");
          Console.WriteLine ("Enter y/n: ");
          response = Console.ReadLine ();
        }

        if (response == "n") {
          isPlaying = false;
          Console.WriteLine ("Thanks for playing!");

        } else {
          idx++;
        }
      }
    }
  }
}