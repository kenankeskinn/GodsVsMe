namespace GodsVsMe.EnemyManager
{
    enum Bosses
    {
        Ruler_OF_The_Earth,
        Ruler_OF_The_Sky,
        Ruler_OF_The_Ocean,
        Ruler_OF_The_Core,
        Ruler_OF_The_Darkness
    }

    enum Rivals
    {
        Level1Rival,
        Level2Rival,
        Level3Rival,
        Level4Rival,
        Level5Rival,
        Level6Rival,
        Level7Rival,
        Level8Rival,
        Level9Rival,
        Level10Rival
    }

    interface IEnemy
    {
        int HEALTH { get; }
        int DAMAGE { get;  }

        void DealDamage();
        void GetDamage(int damage);
    }
}
