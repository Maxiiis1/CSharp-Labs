using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class ComputerCaseRepository : IRepository<IComputerCase>
{
    private readonly Dictionary<string, IComputerCase> _components;
    public ComputerCaseRepository()
    {
        ICaseBuilderDirector builderDirector1 = new GaminCaseBuilderDirector();
        ICaseBuilderDirector builderDirector2 = new OfficeCaseBuilderDirector();

        ICaseBuilder builder1 = builderDirector1.Direct(new CaseBuilder());
        ICaseBuilder builder2 = builderDirector2.Direct(new CaseBuilder());

        _components = new Dictionary<string, IComputerCase>
        {
            { "OfficeCase", builder2.Build() },
            { "GamingCase", builder1.Build() },
        };
    }

    public IComputerCase GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IComputerCase item)
    {
        _components[name] = item;
    }
}