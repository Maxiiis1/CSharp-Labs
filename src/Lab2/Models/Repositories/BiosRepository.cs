using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class BiosRepository : IRepository<IBios>
{
    private readonly Dictionary<string, IBios> _components;

    public BiosRepository()
    {
        IBiosBuilderDirector biosBuilderDirector1 = new AmdBiosBuilderDirector();
        IBiosBuilderDirector biosBuilderDirector2 = new IntelBiosBuilderDirector();

        IBuilderBios builderBios1 = biosBuilderDirector1.Direct(new BiosBuilder());
        IBuilderBios builderBios2 = biosBuilderDirector2.Direct(new BiosBuilder());

        _components = new Dictionary<string, IBios>
        {
            { "AmdBios",  builderBios1.Build() },
            { "IntelBios", builderBios2.Build() },
        };
    }

    public IBios GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IBios item)
    {
        _components[name] = item;
    }
}