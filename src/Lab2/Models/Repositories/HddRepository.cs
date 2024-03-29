using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class HddRepository : IRepository<IHdd>
{
    private readonly Dictionary<string, IHdd> _components;

    public HddRepository()
    {
        IHddBuilderDirector builderDirector1 = new LargeHddBuilderDirector();
        IHddBuilder builder1 = builderDirector1.Direct(new HddBuilder());

        _components = new Dictionary<string, IHdd>
        {
            { "LargeHdd", builder1.Build() },
        };
    }

    public IHdd GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IHdd item)
    {
        _components[name] = item;
    }
}