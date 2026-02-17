using GodsVsMe.PlayerManager;

namespace GodsVsMe.EnemyManager
{
    internal static class Creature
    {
        internal class Zombie : IEnemy
        {
            public int HEALTH { get; private set; }
            public int DAMAGE { get; private set; }

            internal Zombie()
            {
                HEALTH = 50;
                DAMAGE = 10;
            }

            public void DealDamage()
            {
                Player.HEALTH -= DAMAGE;
            }
            public void GetDamage(int damage)
            {
                HEALTH -= damage;
            }
        }

        internal class Skeleton : IEnemy
        {
            public int HEALTH { get; private set; }
            public int DAMAGE { get; private set; }

            internal Skeleton()
            {
                HEALTH = 100;
                DAMAGE = 20;
            }

            public void DealDamage()
            {
                Player.HEALTH -= DAMAGE;
            }
            public void GetDamage(int damage)
            {
                HEALTH -= damage;
            }
        }

        internal class Golem : IEnemy
        {
            public int HEALTH { get; private set; }
            public int DAMAGE { get; private set; }

            internal Golem()
            {
                HEALTH = 200;
                DAMAGE = 30;
            }

            public void DealDamage()
            {
                Player.HEALTH -= DAMAGE;
            }
            public void GetDamage(int damage)
            {
                HEALTH -= damage;
            }
        }

        internal class Boss : IEnemy
        {
            public int HEALTH { get; private set; }
            public int DAMAGE { get; private set; }

            internal Boss(Bosses boss_type)
            {
                switch (boss_type)
                {
                    case Bosses.Ruler_OF_The_Earth:
                        HEALTH = 300;
                        DAMAGE = 100;
                        break;

                    case Bosses.Ruler_OF_The_Sky:
                        HEALTH = 500;
                        DAMAGE = 150;
                        break;
                    case Bosses.Ruler_OF_The_Ocean:
                        HEALTH = 800;
                        DAMAGE = 200;
                        break;
                    case Bosses.Ruler_OF_The_Core:
                        HEALTH = 1000;
                        DAMAGE = 250;
                        break;
                    case Bosses.Ruler_OF_The_Darkness:
                        HEALTH = 3000;
                        DAMAGE = 500;
                        break;
                    default:
                        break;
                }
            }

            public void DealDamage()
            {
                Player.HEALTH -= DAMAGE;
            }
            public void GetDamage(int damage)
            {
                HEALTH -= damage;
            }
        }

    }
}
