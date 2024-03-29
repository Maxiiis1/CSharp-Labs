namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

public class LargeHddBuilderDirector : IHddBuilderDirector
{
    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        hddBuilder.SetPowerConsumption(30)
            .SetCapacity(3000)
            .SetWorkSpeed(7000);
        return hddBuilder;
    }
}