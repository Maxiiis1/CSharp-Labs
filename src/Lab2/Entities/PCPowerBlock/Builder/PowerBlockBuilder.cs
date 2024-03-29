namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock.Builder;

public class PowerBlockBuilder : IPowerBlockBuilder
{
    private int MaxPowerLoad { get; set; }

    public IPowerBlockBuilder SetMaxPowerLoad(int maxPowerLoad)
    {
        MaxPowerLoad = maxPowerLoad;
        return this;
    }

    public IPowerBlock Build()
    {
        return new PowerBlock(MaxPowerLoad);
    }
}