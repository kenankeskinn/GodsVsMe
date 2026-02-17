using System;
using GodsVsMe.PlayerManager;

namespace GodsVsMe.ItemManager
{
    internal abstract class Item
    {
        internal ItemType TYPE { get; set; }
        internal string NAME { get; set; }
        internal int PRICE { get; set; }
    }

    internal static class Items
    {
        internal class Sword : Item
        {
            internal int SwordDamage { get; set; }
            internal Sword(Swords sword)
            {
                TYPE = ItemType.Sword;

                switch (sword)
                {
                    case Swords.Iron_Sword:
                        NAME = "Iron Sword";
                        PRICE = 100;
                        SwordDamage = 10;
                        break;
                    case Swords.Steel_Long_Sword:
                        NAME = "Steel Long Sword";
                        PRICE = 150;
                        SwordDamage = 20;
                        break;
                    case Swords.Excalibur:
                        NAME = "Excalibur";
                        PRICE = 250;
                        SwordDamage = 30;
                        break;
                    default:
                        SwordDamage = 0;
                        break;
                }
            }
        }

        internal class Armor : Item
        {
            internal int ArmorProtection { get; set; }
            internal Armor(Armors armor)
            {
                TYPE = ItemType.Armor;

                switch (armor)
                {
                    case Armors.Leather_Armor:
                        NAME = "Leather Armor";
                        PRICE = 100;
                        ArmorProtection = 10;
                        break;
                    case Armors.Chainmail_Armor:
                        NAME = "Chainmail Armor";
                        PRICE = 150;
                        ArmorProtection = 20;
                        break;
                    case Armors.Plate_Armor:
                        NAME = "Plate Armor";
                        PRICE = 250;
                        ArmorProtection = 30;
                        break;
                    default:
                        ArmorProtection = 0;
                        break;
                }
            }
        }

        internal class Scroll : Item
        {
            internal int ScrollDamage { get; set; }
            internal Scroll(Scrolls scroll)
            {
                TYPE = ItemType.Scroll;

                switch (scroll)
                {
                    case Scrolls.Fireball_Scroll:
                        NAME = "Fireball Scroll";
                        PRICE = 100;
                        ScrollDamage = 30;
                        break;
                    case Scrolls.Ice_Scroll:
                        NAME = "Ice Scroll";
                        PRICE = 150;
                        ScrollDamage = 40;
                        break;
                    case Scrolls.Lightning_Scroll:
                        NAME = "Lightning Scroll";
                        PRICE = 250;
                        ScrollDamage = 50;
                        break;
                    default:
                        ScrollDamage = 0;
                        break;
                }
            }
        }

        internal class Potion : Item
        {
            Potions PotionType;
            internal Potion(Potions potion)
            {
                TYPE = ItemType.Potion;
                PotionType = potion;

                switch (potion)
                {
                    case Potions.Health_Potion:
                        NAME = "Health Potion";
                        PRICE = 100;
                        break;
                    case Potions.Strength_Potion:
                        NAME = "Strength Potion";
                        PRICE = 200;
                        break;
                    case Potions.Defense_Potion:
                        NAME = "Defense Potion";
                        PRICE = 200;
                        break;
                    default:
                        break;
                }
            }

            internal void Use()
            {
                switch (PotionType)
                {
                    case Potions.Health_Potion:
                        break;
                    case Potions.Strength_Potion:
                        break;
                    case Potions.Defense_Potion:
                        break;
                    default:
                        break;

                }
            }
        }
    }

    internal enum Swords
    {
        Iron_Sword,
        Steel_Long_Sword,
        Excalibur
    }
    internal enum Armors
    {
        Leather_Armor,
        Chainmail_Armor,
        Plate_Armor
    }
    internal enum Scrolls
    {
        Fireball_Scroll,
        Ice_Scroll,
        Lightning_Scroll
    }
    internal enum Potions
    {
        Health_Potion,
        Strength_Potion,
        Defense_Potion
    }
    public enum ItemType
    {
        Sword,
        Armor,
        Scroll,
        Potion
    }
}
