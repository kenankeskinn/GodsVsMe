using GodsVsMe.ItemManager;
using System;
using System.Collections.Generic;
using static GodsVsMe.ItemManager.Items;

namespace GodsVsMe.PlayerManager
{
    internal static class Player
    {
        #region Attributes
        #region Private Attributes
        static string username;
        static Race race;

        private static int health;
        private static int level;
        private static int xp;
        private static int gold;

        private static int strength; // Will increase by 2x for the warrior
        private static int defense;  // Will increase by 2x for the tank
        private static int ability;  // Will increase by 2x for the mage

        private static float SwordDamage;
        private static float ScrollMagic;
        private static float ArmorProtection;

        private static Item[] inventory = new Item[5];
        /* 
         The player can only carry 5 items at a time, this will be used to store the player's items. 
         * Inventory[0] = Sword
         * Inventory[1] = Armor
         * Inventory[2] = Scroll
         * Inventory[3] = Potion
         * Inventory[4] = Potion2
        */
        #endregion

        #region Properties
        internal static string USERNAME {  get { return username; } }
        internal static Race RACE { get { return race; } }

        internal static int LEVEL
        {
            get { return level; }
            set { level = value; }
        }
        internal static int HEALTH
        {
            get { return health; }
            set 
            { 
                if (value < 0) value = 0; // Health cannot be negative
                health = value;
            }
        }
        internal static int XP
        {
            get { return xp; }
            set { xp = value; }
        }
        internal static int GOLD
        {
            get { return gold; }
            private set 
            {
                if (value < 0) value = 0;
                gold = value; 
            }
        }

        internal static int STRENGTH
        {
            get { return strength; }
            set { strength = value; }
        }
        internal static int DEFENSE
        {
            get { return defense; }
            set { defense = value; }
        }
        internal static int ABILITY
        {
            get { return ability; }
            set { ability = value; }
        }

        internal static float PHYSICAL_DAMAGE // readonly, calculated based on strength and sword damage
        {
            get { return (strength + SwordDamage) * 10; }
        }
        internal static float MAGICAL_DAMAGE // readonly, calculated based on ability and scroll magic
        {
            get { return (ability + ScrollMagic) * 5; }
        }
        internal static float EVASION_CHANCE // readonly, calculated based on defense and armor protection
        {
            get { return (defense + ArmorProtection) * 0.05f; }
        }
        
        internal static Item[] INVENTORY
        {
            get { return inventory; }
            set { inventory = value; }
        }
        #endregion
        #endregion

        #region Functions
        internal static void CreatePlayer(string username, Race race) // This function initializes the player's attributes based on their chosen.
        {
            // Set the player's information
            Player.username = username;
            Player.race = race;

            // Set the player's initial attributes
            HEALTH = 100;
            LEVEL = 1;
            XP = 1;
            GOLD = 0;
            
            // Set the player's race
            RaceOperations.SelectRace();

            /*
             * For Warr: Physical Damage = 30, Magical Damage = 5,  Evasion Chance = %10
             * For Mage: Physical Damage = 10, Magical Damage = 10, Evasion Chance = %30
             * For Tank: Physical Damage = 10, Magical Damage = 5,  Evasion Chance = %20
            */
        }
        #region Inventory Operations
        internal static void AddItemToInventory(Item item)
        {
            int input;

            if (item.TYPE == ItemType.Sword) INVENTORY[0] = item;
            else if (item.TYPE == ItemType.Armor) INVENTORY[1] = item;
            else if (item.TYPE == ItemType.Scroll) INVENTORY[2] = item;
            else if (item.TYPE == ItemType.Potion)
            {
                Console.WriteLine("Which potion slot would you like to use?");
                if (INVENTORY[3] == null) Console.WriteLine("Potion 1: EMPTY");
                else Console.WriteLine("Potion 1: " + item.NAME);
                if (INVENTORY[4] == null) Console.WriteLine("Potion 2: EMPTY");
                else Console.WriteLine("Potion 2: " + item.NAME);

                Console.Write("Selection: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 1) INVENTORY[3] = item;
                else if (input == 2) INVENTORY[4] = item;
            }
        }

        internal static void RemoveItemFromInventory(Item item)
        {
            for (int i = 0; i <= INVENTORY.Length; i++)
            {
                if (INVENTORY[i] != null && INVENTORY[i].NAME == item.NAME) 
                {
                    INVENTORY[i] = null; 
                    break; 
                }
            }
        }

        internal static void ShowInventory()
        {
            Console.WriteLine("\nInventory");

            Console.Write("Sword: "); 
            if (INVENTORY[0] != null) Console.WriteLine(INVENTORY[0].NAME);
            else Console.WriteLine("EMPTY INVENTORY SLOT");

            Console.Write("Armor: ");
            if (INVENTORY[1] != null) Console.WriteLine(INVENTORY[1].NAME);
            else Console.WriteLine("EMPTY INVENTORY SLOT");

            Console.Write("Scroll: ");
            if (INVENTORY[2] != null) Console.WriteLine(INVENTORY[2].NAME);
            else Console.WriteLine("EMPTY INVENTORY SLOT");

            Console.Write("Potion 1: ");
            if (INVENTORY[3] != null) Console.WriteLine(INVENTORY[3].NAME);
            else Console.WriteLine("EMPTY INVENTORY SLOT");

            Console.Write("Potion 2: ");
            if (INVENTORY[4] != null) Console.WriteLine(INVENTORY[4].NAME);
            else Console.WriteLine("EMPTY INVENTORY SLOT");
        }

        internal static bool isSlotEmpty(Item item)
        {
            if (item.TYPE == ItemType.Sword)
            {
                if (INVENTORY[0] == null) return true;
                else return false;
            }
            else if (item.TYPE == ItemType.Armor)
            {
                if (INVENTORY[1] == null) return true;
                else return false;
            }
            else if (item.TYPE == ItemType.Scroll)
            {
                if (INVENTORY[2] == null) return true;
                else return false;
            }
            else if (item.TYPE == ItemType.Potion)
            {
                if (INVENTORY[3] == null || INVENTORY[4] == null) return true;
                else return false;
            }
            else return false;
        }

        internal static Item ReturnItemInSlot(Item item)
        {
            if (item.TYPE == ItemType.Sword) return INVENTORY[0];
            else if (item.TYPE == ItemType.Armor) return INVENTORY[1];
            else if (item.TYPE == ItemType.Scroll) return INVENTORY[2];
            else if (item.TYPE == ItemType.Potion)
            {
                if (INVENTORY[3] != null) return INVENTORY[3];
                else if (INVENTORY[4] != null) return INVENTORY[4];
                else return null;
            }
            else return null;
        }
        #endregion
        internal static void ShowAllAttributes()
        {
            Console.WriteLine("\nUsername: " + username);
            Console.WriteLine("Race: " + race);
            Console.WriteLine("Health: " + HEALTH);
            Console.WriteLine("Level: " + LEVEL);
            Console.WriteLine("XP: " + XP);
            Console.WriteLine("Gold: " + GOLD);
            Console.WriteLine("Strength: " + STRENGTH);
            Console.WriteLine("Defense: " + DEFENSE);
            Console.WriteLine("Ability: " + ABILITY);
            Console.WriteLine("Physical Damage: " + PHYSICAL_DAMAGE);
            Console.WriteLine("Magical Damage: " + MAGICAL_DAMAGE);
            Console.WriteLine("Evasion Chance: " + EVASION_CHANCE * 100 + "%");
        }

        internal static void ChangeGold(int gold_amount)
        {
            Console.WriteLine($"Old Gold Amount: {GOLD}");
            GOLD += gold_amount;
            Console.WriteLine($"New Gold Amount: {GOLD}");
        }
        #endregion
    }
}