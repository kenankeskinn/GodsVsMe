using System;
using System.Collections.Generic;
using GodsVsMe.ItemManager;

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
                value = health;
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
            private set { gold = value; }
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

        internal static void AddItemToInventory(Items.Sword sword)
        {
            INVENTORY[0] = sword;
        }

        internal static void AddItemToInventory(Items.Armor armor)
        {
            INVENTORY[1] = armor;
        }

        internal static void AddItemToInventory(Items.Scroll scroll)
        {
            INVENTORY[2] = scroll;
        }

        internal static void AddItemToInventory(Items.Potion potion, bool isFirstSlot)
        {
            if (isFirstSlot) INVENTORY[3] = potion; // First Slot
            else INVENTORY[4] = potion;             // Second Slot
        }

        internal static void ShowInventory()
        {
            Console.WriteLine("Inventory");
            foreach (var item in inventory)
            {
                if (item == null) Console.WriteLine("EMPTY INVENTORY SLOT");
                else Console.WriteLine(item.NAME);
            }
        }

        internal static void ShowAllAttributes()
        {
            Console.WriteLine("Username: " + username);
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
        #endregion
    }
}