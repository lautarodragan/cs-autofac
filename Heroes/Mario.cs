using LautaroDragan.Samples.Autofac.Monsters;

namespace LautaroDragan.Samples.Autofac.Heroes
{
    class Mario : IHero
    {
        private IMonster monster;

        public Mario(IMonster monster)
        {
            this.monster = monster;
        }

        public void Fight()
        {
            System.Console.WriteLine("Mario jumped on " + monster.GetName());
        }
    }
}
