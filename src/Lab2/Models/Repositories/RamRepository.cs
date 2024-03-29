using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class RamRepository : IRepository<IRam>
{
    private readonly Dictionary<string, IRam> _components;
    public RamRepository()
    {
        IRamBuilderDirector builderDirector1 = new LargeRamBuilderDirector();

        IRamBuilder builder1 = builderDirector1.Direct(new RamBuilder());

        _components = new Dictionary<string, IRam>
        {
            { "LargeRam", builder1.Build() },
        };
    }

    public IRam GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IRam item)
    {
        _components[name] = item;
    }
}