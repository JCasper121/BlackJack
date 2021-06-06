using System;
using System.Collections.Generic;
using static consoleGame.tools;

namespace consoleGame
{
    public class shuffNDeal
    {
        //Returns a "deck of cards" as a List<string> of 52 elements
        public static List<string> ResetDeck()
        {
            string[] SUITS = new string[] { "Spades", "Clubs", "Diamonds", "Hearts" };

            string[] VALS = new string[] {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                                             "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            List<string> deck = new List<string>();

            for (int x = 0; x < SUITS.Length; ++x)
            {
                for (int y = 0; y < VALS.Length; ++y)
                {
                    string card = VALS[y] + " of " + SUITS[x];
                    deck.Add(card);
                }
            }
            return deck;
        }

        //Uses 5 iterations of Fischer-Yates shuffle to randomize the order of the deck
        public static List<string> Shuffle(List<string> deck)
        {
            int n = deck.Count;
            string placeHolder;

            for (int i = 0; i < 5; ++i)
            {
                while (n > 1)
                {
                    --n;
                    Random random = new Random();
                    int k = random.Next(deck.Count);
                    placeHolder = deck[n];
                    deck[n] = deck[k];
                    deck[k] = placeHolder;
                }
                n = deck.Count;
            }
            return deck;
        }

        public static List<string> Deal(List<string> shuffled)
        {
            List<string> hand = new List<string>();
            hand.Add(shuffled[0]);
            hand.Add(shuffled[1]);
            shuffled.Remove(hand[0]);
            shuffled.Remove(hand[1]);
            return hand;
        }

        public static List<string> Hit(ref List<string> shuffled, List<string> hand)
        {
            hand.Add(shuffled[0]);
            shuffled.RemoveAt(0);
            return hand;
        }

    }
}