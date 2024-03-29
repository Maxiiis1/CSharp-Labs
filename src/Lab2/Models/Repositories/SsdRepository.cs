using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class SsdRepository : IRepository<ISsd>
{
    private readonly Dictionary<string, ISsd> _components;
    public SsdRepository()
    {
        ISsdBuilderDirector builderDirector1 = new LargeSsdBuilderDirector();

        ISsdBuilder builder1 = builderDirector1.Direct(new SsdBuilder());

        _components = new Dictionary<string, ISsd>
        {
            { "LargeSsd", builder1.Build() },
        };
    }

    public ISsd GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, ISsd item)
    {
        _components[name] = item;
    }
}