using Autofac;
using LautaroDragan.Samples.Autofac.Monsters;

namespace LautaroDragan.Samples.Autofac
{
    class Program
    {
        private static IContainer Container { get; set; }

        private enum HeroicColor
        {
            Red, Green
        }

        private const HeroicColor FavoriteColor = HeroicColor.Green;

        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            if (FavoriteColor == HeroicColor.Red)
            {
                builder.RegisterType<Mario>().As<IHero>();
                builder.RegisterType<Goomba>().As<IMonster>();
            }
            else
            {
                builder.RegisterType<Link>().As<IHero>();
                builder.RegisterType<Octorok>().As<IMonster>();
            }

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var hero = scope.Resolve<IHero>();
                hero.Fight();
            }

            System.Console.ReadLine();
        }

    }
}
