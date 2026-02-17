using GodsVsMe.GameManager;
using GodsVsMe.PlayerManager;
using System;

namespace GodsVsMe.ItemManager
{
    internal static class Market
    {
        static int input;

        internal static void BuyItems()
        {
            Console.WriteLine("\nBuy Item");
            
        }
        internal static void SellItems()
        {
            Console.WriteLine("\nSell Item");

            int i = 0;
            foreach (var item in Player.INVENTORY)
            {
                if (item == null) continue;
                else
                {
                    Console.WriteLine($"{i + 1}: {item.NAME} ({item.PRICE - 50} GOLD)");
                    i++;
                }
            }

            if (i == 0) 
            {
                Console.WriteLine("You don't have any item in your inventory."); 
                Console.Write("Press enter to continue.."); Console.ReadLine();
                Decisions.Village();
            }
            else
            {
                Console.WriteLine("0: to Exit");

                // Select item for sell
                do
                {
                    Console.Write("\nSelection: ");
                    input = Convert.ToInt32(Console.ReadLine());

                    if (!(input < 0 || input > i)) break;
                    else Console.WriteLine("Invalid Selection. Please try again.");
                } while (true);

                if (input == 0) Decisions.Village();
            }

        }
    }
}
