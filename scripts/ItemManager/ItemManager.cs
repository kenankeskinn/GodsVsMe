using System;
using GodsVsMe.PlayerManager;

namespace GodsVsMe.ItemManager
{
    internal abstract class Item
    {
        public ItemType TYPE { get; protected set; }
        public string NAME { get; protected set; }
        public int PRICE { get; protected set; }
        public EffectType EFFECT_TYPE { get; protected set; }
        public int EFFECT_AMOUNT { get; protected set; }
    }

    internal static class Items
    {
        internal class Sword : Item
        {
            internal Sword(Swords sword)
            {
                TYPE = ItemType.Sword;
                EFFECT_TYPE = EffectType.Damage;

                switch (sword)
                {
                    case Swords.Iron_Sword:
                        NAME = "Iron Sword";
                        PRICE = 100;
                        EFFECT_AMOUNT = 10;
                        break;
                    case Swords.Steel_Long_Sword:
                        NAME = "Steel Long Sword";
                        PRICE = 150;
                        EFFECT_AMOUNT = 20;
                        break;
                    case Swords.Excalibur:
                        NAME = "Excalibur";
                        PRICE = 250;
                        EFFECT_AMOUNT = 30;
                        break;
                    default:
                        EFFECT_AMOUNT = 0;
                        break;
                }
            }
        }

        internal class Armor : Item
        {
            internal Armor(Armors armor)
            {
                TYPE = ItemType.Armor;
                EFFECT_TYPE = EffectType.Protection;

                switch (armor)
                {
                    case Armors.Leather_Armor:
                        NAME = "Leather Armor";
                        PRICE = 100;
                        EFFECT_AMOUNT = 10;
                        break;
                    case Armors.Chainmail_Armor:
                        NAME = "Chainmail Armor";
                        PRICE = 150;
                        EFFECT_AMOUNT = 20;
                        break;
                    case Armors.Plate_Armor:
                        NAME = "Plate Armor";
                        PRICE = 250;
                        EFFECT_AMOUNT = 30;
                        break;
                    default:
                        EFFECT_AMOUNT = 0;
                        break;
                }
            }
        }

        internal class Scroll : Item
        {
            internal Scroll(Scrolls scroll)
            {
                TYPE = ItemType.Scroll;

                switch (scroll)
                {
                    case Scrolls.Fireball_Scroll:
                        NAME = "Fireball Scroll";
                        PRICE = 100;
                        EFFECT_TYPE = EffectType.Damage;
                        EFFECT_AMOUNT = 30;
                        break;
                    case Scrolls.Ice_Scroll:
                        NAME = "Ice Scroll";
                        PRICE = 150;
                        EFFECT_AMOUNT = 40;
                        break;
                    case Scrolls.Lightning_Scroll:
                        NAME = "Lightning Scroll";
                        PRICE = 250;
                        EFFECT_AMOUNT = 50;
                        break;
                    default:
                        EFFECT_AMOUNT = 0;
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
                        EFFECT_TYPE = EffectType.Health;
                        EFFECT_AMOUNT = 30;
                        PRICE = 100;
                        break;
                    case Potions.Strength_Potion:
                        NAME = "Strength Potion";
                        EFFECT_TYPE = EffectType.Strength;
                        EFFECT_AMOUNT = 20;
                        PRICE = 200;
                        break;
                    case Potions.Defense_Potion:
                        NAME = "Defense Potion";
                        EFFECT_TYPE = EffectType.Defense;
                        EFFECT_AMOUNT = 20;
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
    internal enum ItemType
    {
        Sword,
        Armor,
        Scroll,
        Potion
    }

    internal enum EffectType
    {
        Damage,
        Protection,
        Health,
        Strength,
        Defense
    }
}
