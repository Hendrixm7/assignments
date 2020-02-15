using System;
using System.Collections.Generic;

namespace BlackJackGame {
    public class Deck {
        public Deck () {
            // Constructor

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
        }
    }

}