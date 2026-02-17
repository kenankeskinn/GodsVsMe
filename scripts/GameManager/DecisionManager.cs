using System;
using GodsVsMe.PlayerManager;

namespace GodsVsMe.GameManager
{
    internal static class Decisions
    {
        static int input;
        internal static void Village()
        {
            Console.Clear();
            Console.WriteLine("- VILLAGE -");
            Console.WriteLine("Select Your Way");
            Console.WriteLine("1: Market (You can take items from Market)");
            Console.WriteLine("2: Arena (You can fight with other Fighters)");
            Console.Write("3: Journey (You can continue your journey)");
            if (Player.LEVEL != 3)
            {
                Console.WriteLine(" [LOCKED UP TO LEVEL 3]");
            }
            else
            {
                Console.WriteLine();
            }

            Console.Write("Selection: ");
            input = Convert.ToInt32(Console.ReadLine());

            if (input == 1) Market();
            else if (input == 2) Arena();
            else if (input == 3 && Player.LEVEL == 3) Journey();
            else { Console.Write("Invalid Selection. Please try again."); Console.ReadLine(); Village(); }
        }

        internal static void Market()
        {
            Console.Clear();
            Console.WriteLine("- MARKET -");
            Console.WriteLine("Welcome to the Market! Here you can buy and sell items.");
            Console.WriteLine("1: Buy Items");
            Console.WriteLine("2: Sell Items");
            Console.WriteLine("3: Exit Market");

            Console.Write("Selection: ");
            input = Convert.ToInt32(Console.ReadLine());

            if (input == 1) { ItemManager.Market.BuyItems(); }
            else if (input == 2) { ItemManager.Market.SellItems(); }
            else if (input == 3) { Village(); }
            else { Console.Write("Invalid Selection. Please try again."); Console.ReadLine(); Market(); }
        }

        internal static void Arena()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Arena ! Here you can fight with other fighters for improve yourself");

        }

        internal static void Journey()
        {
            Console.Clear();
        }
    }
}
