using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class ComputerRepository : IRepository<IComputer>
{
    private readonly Dictionary<string, IComputer> _components;

    public ComputerRepository()
    {
        IComputerBuilderDirector builderDirector1 = new GamingComputerBuilderDirector();
        IComputerBuilderDirector builderDirector2 = new OfficeComputerBuilderDirector();

        IComputerBuilder builder1 = builderDirector1.Direct(new ComputerBuilder());
        IComputerBuilder builder2 = builderDirector2.Direct(new ComputerBuilder());

        var computer1 = builder1.Build() as BuildResult.SuccessBuild;
        var computer2 = builder2.Build() as BuildResult.SuccessBuild;

        _components = new Dictionary<string, IComputer>
        {
            { "GamingComputer", computer1.Computer },
            { "OfficeComputer", computer2.Computer },
        };
    }

    public IComputer GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IComputer item)
    {
        _components[name] = item;
    }
}