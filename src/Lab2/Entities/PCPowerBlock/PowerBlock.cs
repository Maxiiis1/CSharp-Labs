namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;

public class PowerBlock : IPowerBlock
{
    public PowerBlock(int maxPowerLoad)
    {
        MaxPowerLoad = maxPowerLoad;
    }

    public int MaxPowerLoad { get; }
}