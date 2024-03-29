using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class MotherBoardRepository : IRepository<IMotherBoard>
{
    private readonly Dictionary<string, IMotherBoard> _components;

    public MotherBoardRepository()
    {
        IMotherBoardBuilderDirector builderDirector1 = new OfficeMotherBoardBuilderDirector();
        IMotherBoardBuilderDirector builderDirector2 = new GamingMotherBoardBuilderDirector();

        IMotherBoardBuilder builder1 = builderDirector1.Direct(new MotherBoardWithWiFiBuilder());
        IMotherBoardBuilder builder2 = builderDirector2.Direct(new MotherBoardWithWiFiBuilder());

        _components = new Dictionary<string, IMotherBoard>
        {
            { "OfficeMotherBoard", builder1.Build() },
            { "GamingMotherBoard", builder2.Build() },
        };
    }

    public IMotherBoard GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IMotherBoard item)
    {
        _components[name] = item;
    }
}