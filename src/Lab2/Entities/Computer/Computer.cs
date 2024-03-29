using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public class Computer : IComputer
{
    public Computer(IComputerCase computerCase, IPowerBlock block, IMotherBoard motherBoard)
    {
        ComputerCase = computerCase;
        PowerBlock = block;
        MotherBoard = motherBoard;
    }

    public IComputerCase ComputerCase { get; }
    public IPowerBlock PowerBlock { get; }
    public IMotherBoard MotherBoard { get; }

    public IComputerBuilder Direct(IComputerBuilder computerBuilder)
    {
        computerBuilder.SetCase(ComputerCase)
            .SetMotherBoard(MotherBoard)
            .SetPowerBlock(PowerBlock);
        return computerBuilder;
    }
}