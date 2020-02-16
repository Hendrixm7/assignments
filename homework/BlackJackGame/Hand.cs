using System;
using System.Collections.Generic;

namespace BlackJackGame {
    public class Hand {

        //Properties
        public List<Card> cards = new List<Card> ();
        public int value {
            get {
                int value = 0;

                for (int i = 0; i < cards.Count; i++) {
                    value += cards[i].GetCardValue ();

                }

                return value;
            }
        }

        //Method
        public void AddCard (Card card) {
            cards.Add (card);
        }

        public void DisplayHand () {
            Console.Write ("Cards: ");

            for (int i = 0; i < cards.Count; i++) {
                Console.Write ($"{cards[i].DisplayCard()} ");
            }

            Console.Write ("\n");
            Console.WriteLine ($"Total: {value}");
        }

        public bool DidBust () {
            return value > 21;
        }

        public bool HasBlackjack () {
            return (value == 21) && (cards.Count == 2);
        }
    }
}