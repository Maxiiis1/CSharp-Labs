namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

public interface ISsdBuilder
{
    ISsdBuilder SetCapacity(int capacity);
    ISsdBuilder SetWorkSpeed(int speed);
    ISsdBuilder SetPowerConsumption(int consumption);
    ISsdBuilder SetConnectionType(string type);
    ISsd Build();
}