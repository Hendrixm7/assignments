using System;
using System.Collections.Generic;

namespace Shuffle {
  class Program {
    static void Main (string[] args) {
      var deckSuit = new List<string> () { "Hearts", "Diamonds", "Spades", "Clubs" };
      var deckFace = new List<string> () { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      var deck = new List<Card> ();

      // Fill/create deck
      for (var i = 0; i < deckSuit.Count; i++) {
        for (var j = 0; j < deckFace.Count; j++) {
          var Card = ($"{deckFace[j]} of {deckSuit[i]}");
          deck.Add (new Card ());

        }
        var card = new Card ();
        deck.Face = deckFace[j];
        card.Suit = deckSuit[i];
        if (card.Suit == "diamonds" || card.Suit == "hearts") {
          card.ColorOfTheCard = "red";
        } else {
          card.ColorOfTheCard = "black";
        }
        deck.Add (card);

      }
    }
    for (int i = deck.Count - 1; i >= 1; i--) {
      var j = new Random ().Next (i);
      var temp = deck[j];
      deck[j] = deck[i];
      deck[i] = temp;
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

  }
}
}