using System;
using GodsVsMe.PlayerManager;
using GodsVsMe.GameManager;
using GodsVsMe.ItemManager;

namespace GodsVsMe
{
    internal class main
    {
        static void Main(string[] args)
        {
            Player.CreatePlayer("Kenan", Race.Warrior);
            Player.ShowAllAttributes(); Console.WriteLine();
            Player.AddItemToInventory(new Items.Sword(Swords.Excalibur));
            Player.AddItemToInventory(new Items.Potion(Potions.Health_Potion));
            Player.AddItemToInventory(new Items.Potion(Potions.Strength_Potion));
            Player.ChangeGold(+200);
            Decisions.Village();
        }
    }
}
