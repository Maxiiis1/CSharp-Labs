using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public class Ssd : ISsd
{
    public Ssd(int powerConsumption, int capacity, string connectionType, int workSpeed)
    {
        PowerConsumption = powerConsumption;
        ConnectionType = connectionType;
        WorkSpeed = workSpeed;
        Capacity = capacity;
    }

    public string ConnectionType { get; }
    public int Capacity { get; }
    public int WorkSpeed { get; }
    public int PowerConsumption { get; }
    public ISsdBuilder Direct(ISsdBuilder ssdBuilder)
    {
        ssdBuilder.SetCapacity(Capacity)
            .SetPowerConsumption(PowerConsumption)
            .SetConnectionType(ConnectionType)
            .SetWorkSpeed(WorkSpeed);
        return ssdBuilder;
    }
}