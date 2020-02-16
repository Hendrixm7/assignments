using System;
using System.Collections.Generic;

namespace BlackJackGame {
    public class Game {
        // Properties
        public Deck deck = new Deck ();
        public Hand playerHand = new Hand ();
        public Hand dealerHand = new Hand ();

        // Constructor
        public Game () {
            deck.Shuffle ();

            playerHand.AddCard (deck.DealCard ());
            dealerHand.AddCard (deck.DealCard ());
            playerHand.AddCard (deck.DealCard ());
            dealerHand.AddCard (deck.DealCard ());
        }

        // Methods
        public void Play () {
            Console.WriteLine ("Welcome to Blackjack!");

            Console.WriteLine ("---- PLAYER TURN -----");

            if (dealerHand.HasBlackjack ()) {
                Console.WriteLine ("Dealer has blackjack. Dealer wins!");
                Environment.Exit (0);
            }

            if (playerHand.HasBlackjack ()) {
                Console.WriteLine ("Player has blackjack. Player wins!");
                Environment.Exit (0);
            }

            // Goes forever until "break;"
            while (true) {
                playerHand.DisplayHand ();
                Console.Write ("Hit(1) or Stand(2)?: ");
                var userResponse = Console.ReadLine ();

                // User stands
                if (userResponse == "2") break;

                // User hits
                if (userResponse == "1") {
                    playerHand.AddCard (deck.DealCard ());
                    playerHand.DisplayHand ();

                    if (playerHand.DidBust ()) {
                        Console.WriteLine ("You busted! Dealer Wins.");
                        Environment.Exit (0);
                    }
                }
            }

            // Run dealer
            Console.WriteLine ("---- DEALER TURN -----");

            dealerHand.DisplayHand ();
            while (dealerHand.value <= 17) {
                dealerHand.AddCard (deck.DealCard ());
                dealerHand.DisplayHand ();
                if (dealerHand.DidBust ()) {
                    Console.WriteLine ("Dealer Busted! Player Wins.");
                    Environment.Exit (0);
                }
            }

            if (dealerHand.value >= playerHand.value) {
                Console.WriteLine ("Dealer Wins!");
            } else {
                Console.WriteLine ("Player Wins!");
            }
        }

    }
}