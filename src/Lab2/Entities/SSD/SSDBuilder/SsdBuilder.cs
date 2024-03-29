using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

public class SsdBuilder : ISsdBuilder
{
    private string? ConnectionType { get; set; }
    private int Capacity { get; set; }
    private int WorkSpeed { get; set; }
    private int PowerConsumption { get; set; }

    public ISsdBuilder SetCapacity(int capacity)
    {
        Capacity = capacity;
        return this;
    }

    public ISsdBuilder SetWorkSpeed(int speed)
    {
        WorkSpeed = speed;
        return this;
    }

    public ISsdBuilder SetPowerConsumption(int consumption)
    {
        PowerConsumption = consumption;
        return this;
    }

    public ISsdBuilder SetConnectionType(string type)
    {
        ConnectionType = type;
        return this;
    }

    public ISsd Build()
    {
        return new Ssd(
            PowerConsumption,
            Capacity,
            ConnectionType ?? throw new ArgumentNullException(),
            WorkSpeed);
    }
}