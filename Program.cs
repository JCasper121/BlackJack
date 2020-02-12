using System;
using System.Collections.Generic;
using static consoleGame.shuffNDeal;
using static consoleGame.gameLoop;
using static consoleGame.tools;

namespace consoleGame
{
    class Program
    {
        static void Main()
        {
            int count = 0;
            int playerMoney;
            Console.ResetColor();
            Spacer(8, "  welcome to blackjack  ");
            playerMoney = ValidateEntry(count, 99999);
            subMain(count, playerMoney);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Spacer(8, " thanks for playing blackjack! ");
            return;
        }

        public static void subMain(int count, int playerMoney)
        {
            AlternateColor(count);
            List<string> unShuffled = ResetDeck();
            List<string> shuffled = Shuffle(unShuffled);
            List<string> playerHand = Deal(shuffled);
            List<string> dealerHand = Deal(shuffled);
            Console.WriteLine();
            GameLoop(count, playerMoney, playerHand, dealerHand, shuffled);
            return;
        }
    }
}
