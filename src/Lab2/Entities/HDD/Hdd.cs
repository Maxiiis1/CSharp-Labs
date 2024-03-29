using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;

public class Hdd : IHdd
{
    public Hdd(int capacity, int workSpeed, int powerConsumption)
    {
        Capacity = capacity;
        WorkSpeed = workSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int WorkSpeed { get; }
    public int PowerConsumption { get; }
    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        hddBuilder.SetPowerConsumption(PowerConsumption)
            .SetCapacity(Capacity)
            .SetWorkSpeed(WorkSpeed);
        return hddBuilder;
    }
}