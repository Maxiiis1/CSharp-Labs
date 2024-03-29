using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class CpuCoolerRepository : IRepository<ICpuCooler>
{
    private readonly Dictionary<string, ICpuCooler> _components;

    public CpuCoolerRepository()
    {
        ICoolerBuilderDirector builderDirector1 = new GamingCoolerBuilderDirector();
        ICoolerBuilderDirector builderDirector2 = new OfficeCoolerBuilderDirector();

        ICpuCoolerBuilder builder1 = builderDirector1.Direct(new CpuCoolerBuilder());
        ICpuCoolerBuilder builder2 = builderDirector2.Direct(new CpuCoolerBuilder());

        _components = new Dictionary<string, ICpuCooler>
        {
            { "OfficeCooler", builder2.Build() },
            { "GamingCooler", builder1.Build() },
        };
    }

    public ICpuCooler GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, ICpuCooler item)
    {
        _components[name] = item;
    }
}