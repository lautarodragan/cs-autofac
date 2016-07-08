# c#-autofac
Sample Autofac implementation in C#

This is console application with a basic implementation of dependency injection in C# using [Autofac](https://autofac.org/).

Running the app will open a cmd and display the text `Link swung his sword at Octorok`.

`Link` and `Octorok` are implementations of `IHero` and `IMonster`, injected by Autofac.

Changing the value of `FavoriteColor` in [Program.cs](Program.cs) to `HeroicColor.Red` will instead inject `Mario` and `Goomba` as the implementations of `IHero` and `IMonster`, and display the text `Mario jumped on Goomba` instead.

```cs
private const HeroicColor FavoriteColor = HeroicColor.Red;
```

Implementations of the interfaces are registered using the `RegisterType` method:
```cs
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
```

To manually retrieve an instance of a type from the Autofac container, the `Resolve` method is used:

```cs
using (var scope = Container.BeginLifetimeScope())
{
    var hero = scope.Resolve<IHero>();
    hero.Fight();
}
```

Dependencies in constructors are resolved automatically by Autofac:

```cs
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
```
