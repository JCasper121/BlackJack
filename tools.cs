using System;
using System.Collections.Generic;
using static consoleGame.getValue;

namespace consoleGame
{
    class tools
    {
        //This method takes a text string, and int for size and adds visual banner/spacer in the console.
        public static void Spacer(int num, string text = "-")
        {
            Console.Write("\n");
            if (text == "-")
            {
                text = new String('-', 60);
            }
            else
            {
                text = text.ToUpper();
            }

            for (int i = 0; i < num; ++i)
            {
                Console.WriteLine(new String('-', 60));
                if (i == (num / 2) - 1)
                {
                    int spaces = 60 - text.Length;
                    string space = new String('-', (spaces / 2) - 1);
                    Console.WriteLine(space + " " + text + " " + space);
                }
            }
        }

        public static void AlternateColor(int count)
        {
            count++;
            Console.ResetColor();
            if (count % 2 == 0)//Alternates console text color.
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            count--;
            return;
        }

        public static void PrintHand(string player, bool hide, List<string> hand, int playerBet = 999, int playerMoney = 9999)
        {
            string scoreString;
            Spacer(2, player + " cards:");

            scoreString = GetHandValue(hand);

            for (int i = 0; i < hand.Count; ++i)
            {
                if (i == 0 && playerBet != 999)
                {
                    int cardLen = hand[i].Length;
                    int spaces = 42 - cardLen;
                    string spacesString = new String(' ', spaces);
                    string printLine = hand[i] + spacesString + "Total money: $" + playerMoney;
                    Console.WriteLine(printLine);
                }
                else if (hide && i != 0)
                {
                    Console.Write("\n???-------???");
                }
                else
                {
                    int cardLen = hand[i].Length;

                    if (playerBet != 999 && i == 0)
                    {
                        int spaces = 42 - cardLen;
                        string spacesString = new String(' ', spaces);
                        string printLine = hand[i] + spacesString + "Total money: $" + playerMoney;
                        Console.WriteLine(printLine);
                    }
                    else if (playerBet != 999 && i == 1)
                    {
                        int spaces = 45 - cardLen;
                        string spacesString = new String(' ', spaces);
                        string printLine = hand[i] + spacesString + "Your bet: $" + playerBet;
                        Console.WriteLine(printLine);
                    }
                    else
                        Console.Write("\n{0}", hand[i]);
                }
            }
            if (!hide)
            {
                Console.WriteLine("\nTotal: {0}", scoreString);
            }
            return;
        }

        public static char ValidateEntry(int count, string type)
        {
            char char1;
            char char2;
            bool isValid = false;

            while (!isValid)
            {
                if (type == "hit")
                {
                    Spacer(2, "'h' to hit or 's' to stay");
                    char1 = 'H';
                    char2 = 'S';
                }
                else if (type == "split")
                {
                    Spacer(2, " split? Y/N ");
                    char1 = 'Y';
                    char2 = 'N';
                }
                else
                {
                    Spacer(2, "play another game? y/n");
                    char1 = 'Y';
                    char2 = 'N';

                }
                isValid = char.TryParse(Console.ReadLine().ToUpper(), out char userInput);
                if (isValid && (userInput == char1 || userInput == char2))
                {
                    return userInput;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Spacer(2, "invalid entry");
                    AlternateColor(count);
                    Spacer(2, " press any key to continue: ");
                    Console.ReadKey();
                    isValid = false;
                }
            }
            return 'E';
        }

        public static int ValidateEntry(int count, int totalMoney = 99999)
        {
            bool isValid = false;

            while (!isValid)
            {
                if (totalMoney == 99999)
                {
                    Spacer(2, " how much cash are you bringing to the table? ");
                }
                else
                {
                    Spacer(2, " total cash: $" + totalMoney);
                    Spacer(2, " place your bet ");
                }
                Console.Write(" >> $");
                isValid = int.TryParse(Console.ReadLine().ToUpper(), out int playerMoney);
                if (isValid && playerMoney <= totalMoney)
                {
                    return playerMoney;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Spacer(2, "invalid entry");
                    AlternateColor(count);
                    Spacer(2, " press any key to continue: ");
                    Console.ReadKey();
                    isValid = false;
                }
            }
            return 6969;
        }
    }
}