using System;
using System.Collections.Generic;

namespace BlackJackGame {
  class Program {
    static void Main (string[] args) {
      var deckSuit = new List<string> () { "Hearts", "Diamonds", "Spades", "Clubs" };
      var deckFace = new List<string> () { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      var deck = new List<Card> ();

      // Fill/create deck
      for (var i = 0; i < deckSuit.Count; i++) {
        for (var j = 0; j < deckFace.Count; j++) {
          var singleCard = new Card ();
          singleCard.Rank = deckFace[i];
          singleCard.Suit = deckSuit[j];
          deck.Add (singleCard);
        }

      }

      var playerHand = new List<Card> ();

      var topCard = deck[0];
      deck.RemoveAt (0);
      playerHand.Add (topCard);
      topCard = deck[0];
      deck.RemoveAt (0);
      playerHand.Add (topCard);

      var dealerHand = new List<Card> ();

      topCard = deck[0];
      deck.RemoveAt (0);
      playerHand.Add (topCard);
      topCard = deck[0];
      deck.RemoveAt (0);
      playerHand.Add (topCard);

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

      Player hand = new List<Card> ();

      var topcard = deck[0];

      // Display all cards
      for (int cardIndex = 0; cardIndex < deck.Count; cardIndex++) {
        var card = deck[cardIndex];
        Console.WriteLine (card);
      }

    }
  }
}
}
}