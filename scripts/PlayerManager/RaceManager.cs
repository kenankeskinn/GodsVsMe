using System;
using System.Collections.Generic;

namespace GodsVsMe.PlayerManager
{
    internal enum Race
    {
        Warrior,
        Mage,
        Tank
    }

    internal static class RaceOperations
    {
        internal static void SelectRace()
        {
            // Set the player's attributes based on their chosen
            if (Player.RACE == Race.Warrior)
            {
                Player.STRENGTH = 3;
                Player.DEFENSE = 1;
                Player.ABILITY = 1;
            }
            else if (Player.RACE == Race.Tank)
            {
                Player.STRENGTH = 1;
                Player.DEFENSE = 3;
                Player.ABILITY = 1;
            }
            else if (Player.RACE == Race.Mage)
            {
                Player.STRENGTH = 1;
                Player.DEFENSE = 2;
                Player.ABILITY = 2;
            }
        }
    }
}
