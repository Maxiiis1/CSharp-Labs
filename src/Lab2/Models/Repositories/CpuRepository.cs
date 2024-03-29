using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class CpuRepository : IRepository<ICpu>
{
    private readonly Dictionary<string, ICpu> _components;

    public CpuRepository()
    {
        ICpuBuilderDirector builderDirector1 = new RyzenCpuBuilderDirector();
        ICpuBuilderDirector builderDirector2 = new IntelCpuBuilderDirector();

        ICpuBuilder builder1 = builderDirector1.Direct(new CpuBuilder());
        ICpuBuilder builder2 = builderDirector2.Direct(new CpuBuilder());

        _components = new Dictionary<string, ICpu>
        {
            { "RyzenCpu", builder1.Build() },
            { "IntelCpu", builder2.Build() },
        };
    }

    public ICpu GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, ICpu item)
    {
        _components[name] = item;
    }
}