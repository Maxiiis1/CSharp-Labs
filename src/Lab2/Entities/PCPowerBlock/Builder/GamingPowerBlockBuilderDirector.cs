namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock.Builder;

public class GamingPowerBlockBuilderDirector : IPowerBlockBuilderDirector
{
    public IPowerBlockBuilder Direct(IPowerBlockBuilder powerBlockBuilder)
    {
        powerBlockBuilder.SetMaxPowerLoad(800);
        return powerBlockBuilder;
    }
}