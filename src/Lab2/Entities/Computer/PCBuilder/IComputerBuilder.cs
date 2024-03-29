using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;

public interface IComputerBuilder
{
    IComputerBuilder SetCase(IComputerCase computerCase);
    IComputerBuilder SetPowerBlock(IPowerBlock powerBlock);
    IComputerBuilder SetMotherBoard(IMotherBoard motherBoard);
    BuildResult Build();
}