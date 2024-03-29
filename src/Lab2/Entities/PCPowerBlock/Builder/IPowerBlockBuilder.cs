namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock.Builder;

public interface IPowerBlockBuilder
{
    IPowerBlockBuilder SetMaxPowerLoad(int maxPowerLoad);
    IPowerBlock Build();
}