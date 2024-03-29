using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public interface IComputer : IComputerBuilderDirector
{
    IComputerCase ComputerCase { get; }
    IPowerBlock PowerBlock { get; }
    IMotherBoard MotherBoard { get; }
}