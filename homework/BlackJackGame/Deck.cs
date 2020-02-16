using System;
using System.Collections.Generic;

namespace BlackJackGame {
    public class Deck {
        // Properties
        public List<Card> cards = new List<Card> ();

        // Constructor
        public Deck () {
            var deckSuit = new List<string> () { "♥", "♦", "♠", "♣" };
            var deckFace = new List<string> () { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            // Fill/create deck
            for (var i = 0; i < deckSuit.Count; i++) {
                for (var j = 0; j < deckFace.Count; j++) {
                    var singleCard = new Card ();
                    singleCard.Rank = deckFace[j];
                    singleCard.Suit = deckSuit[i];
                    cards.Add (singleCard);
                }
            }
        }

        // Methods
        public void Shuffle () {
            var rnd = new Random ();

            // Shuffle
            //
            // for i from n - 1 down to 1 do:
            for (int cardIndex = cards.Count - 1; cardIndex >= 1; cardIndex--) {
                //    j = random integer (where 0 <= j <= cardIndex)
                var randomIndex = rnd.Next (cardIndex);

                //    swap deck[cardIndex] with deck[randomIndex]
                var cardAtCardIndex = cards[cardIndex];
                var cardAtRandomIndex = cards[randomIndex];

                cards[cardIndex] = cardAtRandomIndex;
                cards[randomIndex] = cardAtCardIndex;
            }
        }

        public Card DealCard () {
            var card = cards[0];
            cards.RemoveAt (0);
            return card;
        }
    }

}