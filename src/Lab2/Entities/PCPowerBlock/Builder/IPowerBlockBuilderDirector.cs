namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock.Builder;

public interface IPowerBlockBuilderDirector
{
    IPowerBlockBuilder Direct(IPowerBlockBuilder powerBlockBuilder);
}