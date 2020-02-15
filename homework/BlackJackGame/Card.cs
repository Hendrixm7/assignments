namespace BlackJackGame {

    public class Card {

        //WHOLE THING IS A CLASS. SPECIFIC ITEMS BELOW ARE PROPERTIES
        //value
        public int value { get; set; }
        //rank
        public string Rank { get; set; }
        //suit
        public string Suit { get; set; }
        //color
        public string ColorOfTheCard { get; set; }

        //Method
        public string DisplayCard () {
            return $"{Rank} of {Suit}";

        }

        public int GetCardValue () {
            if (Rank == "ace") {
                return 11;
            } else if (Rank == "queen" || Rank == "king" || Rank == "jack") {
                return 10;

            }
            return int.Parse (Rank);
        }
    }
}