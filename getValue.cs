using System;
using System.Collections.Generic;
using static consoleGame.gameLoop;

namespace consoleGame
{
    class getValue
    {
        public static int GetIntValue(List<string> hand)
        {
            string stringVal;
            int intVal;
            stringVal = GetHandValue(hand);

            if (stringVal.Length > 2)//If there was an ACE
                intVal = int.Parse(stringVal.Substring(stringVal.Length - 2));
            else
                intVal = int.Parse(stringVal);

            return intVal;
        }

        public static string GetHandValue(List<string> hand)
        {
            string handValue;
            int handval = 0;
            int handval1 = 0;
            int handval2 = 0;

            Dictionary<string, int> intvals = new Dictionary<string, int>()
            {
                {"Ac", 1}, {"Tw", 2}, {"Th", 3},
                {"Fo", 4}, {"Fi", 5}, {"Si", 6},
                {"Se", 7}, {"Ei", 8}, {"Ni", 9},
                {"Te", 10}, {"Ja", 10}, {"Qu", 10}, {"Ki", 10}
            };

            foreach (string card in hand)
            {
                if (card.Substring(0, 2) == "Ac")
                {
                    handval1 += 1;
                    handval2 += 11;
                }
                else
                    handval += intvals[card.Substring(0, 2)];
            }

            if (handval1 != 0 || handval2 != 0)//If there was an ACE
            {
                handval1 += handval;
                handval2 += handval;
                if (handval2 <= 21)
                    handValue = handval1.ToString() + " or " + handval2.ToString();
                else
                    handValue = handval1.ToString();
            }
            else
                handValue = handval.ToString();

            return handValue;
        }
    }
}