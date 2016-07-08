using LautaroDragan.Samples.Autofac.Monsters;

namespace LautaroDragan.Samples.Autofac
{
    class Link : IHero
    {
        private IMonster monster;

        public Link(IMonster monster)
        {
            this.monster = monster;
        }

        public void Fight()
        {
            System.Console.WriteLine("Link swung his sword at " + monster.GetName());
        }
    }
}
