using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock.Builder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class PowerBlockRepository : IRepository<IPowerBlock>
{
    private readonly Dictionary<string, IPowerBlock> _components;

    public PowerBlockRepository()
    {
        IPowerBlockBuilderDirector builderDirector1 = new GamingPowerBlockBuilderDirector();

        IPowerBlockBuilder builder1 = builderDirector1.Direct(new PowerBlockBuilder());

        _components = new Dictionary<string, IPowerBlock>
        {
            { "GamingPowerBlock", builder1.Build() },
        };
    }

    public IPowerBlock GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IPowerBlock item)
    {
        _components[name] = item;
    }
}