using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;

public class GamingComputerBuilderDirector : IComputerBuilderDirector
{
    public IComputerBuilder Direct(IComputerBuilder computerBuilder)
    {
        IRepository<IMotherBoard> motherBoardRepository = new MotherBoardRepository();
        IRepository<IComputerCase> caseBoardRepository = new ComputerCaseRepository();

        computerBuilder.SetCase(caseBoardRepository.GetComponents("GamingCase"))
            .SetPowerBlock(new PowerBlock(800))
            .SetMotherBoard(motherBoardRepository.GetComponents("GamingMotherBoard"));
        return computerBuilder;
    }
}