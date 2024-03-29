namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

public class LargeSsdBuilderDirector : ISsdBuilderDirector
{
    public ISsdBuilder Direct(ISsdBuilder ssdBuilder)
    {
        ssdBuilder.SetCapacity(2000)
            .SetWorkSpeed(1000)
            .SetConnectionType("Sata")
            .SetPowerConsumption(30);
        return ssdBuilder;
    }
}