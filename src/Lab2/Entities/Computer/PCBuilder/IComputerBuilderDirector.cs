namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;

public interface IComputerBuilderDirector
{
    IComputerBuilder Direct(IComputerBuilder computerBuilder);
}