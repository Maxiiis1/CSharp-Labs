namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

public interface IHddBuilder
{
    IHddBuilder SetCapacity(int capacity);
    IHddBuilder SetWorkSpeed(int speed);
    IHddBuilder SetPowerConsumption(int consumption);
    IHdd Build();
}