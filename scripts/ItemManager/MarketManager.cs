using GodsVsMe.GameManager;
using GodsVsMe.PlayerManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodsVsMe.ItemManager
{
    internal static class Market
    {
        static int input;

        static Dictionary<int, Item> all_items = new Dictionary<int, Item>
        {
            // Swords
            {1 ,new Items.Sword(Swords.Iron_Sword)},
            {2 ,new Items.Sword(Swords.Steel_Long_Sword)},
            {3 ,new Items.Sword(Swords.Excalibur) },

            // Armors
            {4, new Items.Armor(Armors.Leather_Armor)},
            {5, new Items.Armor(Armors.Chainmail_Armor)},
            {6, new Items.Armor(Armors.Plate_Armor)},

            // Scrolls
            {7, new Items.Scroll(Scrolls.Fireball_Scroll)},
            {8, new Items.Scroll(Scrolls.Ice_Scroll)},
            {9, new Items.Scroll(Scrolls.Lightning_Scroll)},

            // Potion
            {10, new Items.Potion(Potions.Health_Potion)},
            {11, new Items.Potion(Potions.Strength_Potion)},
            {12, new Items.Potion(Potions.Defense_Potion)}
        };

        static ItemType[] item_types = { ItemType.Sword, ItemType.Armor, ItemType.Scroll, ItemType.Potion };

        internal static void BuyItem()
        {
            Console.WriteLine("\n---- Buy Item ----");

            foreach (var type in item_types)
            {
                if (type == ItemType.Sword) Console.WriteLine("- Swords -");
                else if (type == ItemType.Armor) Console.WriteLine("- Armors -");
                else if (type == ItemType.Scroll) Console.WriteLine("- Scrolls -");
                else if (type == ItemType.Potion) Console.WriteLine("- Potion -");

                foreach (var item in all_items.Where(i => i.Value.TYPE == type))
                {
                    Console.WriteLine($"{item.Key, -2}: {item.Value.NAME,-20} {item.Value.EFFECT_TYPE,-10}: {item.Value.EFFECT_AMOUNT,-3} {item.Value.PRICE,10} GOLD");
                } Console.WriteLine();
            }

            while (true)
            {
                Console.Write("\nSelection :  ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input > 0 && input < all_items.Count) break;
                else Console.Write("Invalid Selection. Please try again."); Console.ReadLine();
            }
            Item buyable_item = all_items[input];

            string answer;
            if (Player.GOLD >= buyable_item.PRICE) // if player have gold to buy item
            {
                Console.WriteLine("IS SLOT EMPTY: " + Player.isSlotEmpty(buyable_item));
                if (!Player.isSlotEmpty(buyable_item)) // if player has item in the relevant slot in inventory
                {
                    Item current_item = Player.ReturnItemInSlot(all_items[input]);
                    int difference_price = (current_item.PRICE - 50) - (buyable_item.PRICE);
                    Console.WriteLine("\nThis item's slot is full.");
                    Console.WriteLine($"Current Item: {current_item.NAME} ({current_item.PRICE - 50} GOLD for Sell)");
                    Console.WriteLine($"New Item: {buyable_item.NAME} ({buyable_item.PRICE} GOLD for buy)");
                    Console.Write($"Do you wanna sell old item and buy new one (Y/N): ");
                    answer = Console.ReadLine();
                    if (answer == "Y" || answer == "y")
                    {
                        Player.AddItemToInventory(all_items[input]);
                        Player.ChangeGold(difference_price);
                    }
                }
                else
                {
                    Player.AddItemToInventory(all_items[input]);
                    Player.ChangeGold(-all_items[input].PRICE);
                }
            }
            else Console.WriteLine("Not Enough Gold");

            Player.ShowInventory();
            Console.Write("Press Enter to continue..."); Console.ReadLine();
            Decisions.Village();
        }
        internal static void SellItem()
        {
            Dictionary<int, Item> sellable_items = new Dictionary<int, Item>();
            Console.WriteLine("\nSell Item");

            int i = 0;
            foreach (var item in Player.INVENTORY)
            {
                if (item == null) continue;
                else
                {
                    Console.WriteLine($"{i + 1}: {item.NAME} ({item.PRICE - 50} GOLD)");
                    sellable_items.Add(++i, item);
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
                Console.WriteLine("0: Exit");

                // Select item for sell
                do
                {
                    Console.Write("\nSelection: ");
                    input = Convert.ToInt32(Console.ReadLine());

                    if (!(input < 0 || input > i)) break;
                    else Console.WriteLine("Invalid Selection. Please try again.");
                } while (true);

                if (input == 0) Decisions.Village();
                else
                {
                    Player.RemoveItemFromInventory(sellable_items[input]);
                    Player.ChangeGold(sellable_items[input].PRICE - 50);
                    Player.ShowInventory();
                    Console.Write("Press Enter to continue..."); Console.ReadLine();
                    Decisions.Village();
                }
            }
        }
    }
}
