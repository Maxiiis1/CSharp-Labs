namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

public class HddBuilder : IHddBuilder
{
    private int Capacity { get; set; }
    private int WorkSpeed { get; set; }
    private int PowerConsumption { get; set; }

    public IHddBuilder SetCapacity(int capacity)
    {
        Capacity = capacity;
        return this;
    }

    public IHddBuilder SetWorkSpeed(int speed)
    {
        WorkSpeed = speed;
        return this;
    }

    public IHddBuilder SetPowerConsumption(int consumption)
    {
        PowerConsumption = consumption;
        return this;
    }

    public IHdd Build()
    {
        return new Hdd(Capacity, WorkSpeed, PowerConsumption);
    }
}