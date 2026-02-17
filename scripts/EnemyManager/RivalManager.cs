using GodsVsMe.PlayerManager;

namespace GodsVsMe.EnemyManager
{
    internal class Rival : IEnemy
    {
        public int HEALTH { get; private set; }
        public int DAMAGE { get; private set; }

        internal Rival(Rivals rival_type)
        {
            switch (rival_type)
            {
                case Rivals.Level1Rival:
                    HEALTH = 100;
                    DAMAGE = 10;
                    break;
                case Rivals.Level2Rival:
                    HEALTH = 110;
                    DAMAGE = 20;
                    break;
                case Rivals.Level3Rival:
                    HEALTH = 120;
                    DAMAGE = 25;
                    break;
                case Rivals.Level4Rival:
                    HEALTH = 130;
                    DAMAGE = 30;
                    break;
                case Rivals.Level5Rival:
                    HEALTH = 150;
                    DAMAGE = 40;
                    break;
                case Rivals.Level6Rival:
                    HEALTH = 150;
                    DAMAGE = 50;
                    break;
                case Rivals.Level7Rival:
                    HEALTH = 150;
                    DAMAGE = 60;
                    break;
                case Rivals.Level8Rival:
                    HEALTH = 170;
                    DAMAGE = 60;
                    break;
                case Rivals.Level9Rival:
                    HEALTH = 180;
                    DAMAGE = 60;
                    break;
                case Rivals.Level10Rival:
                    HEALTH = 200;
                    DAMAGE = 70;
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
