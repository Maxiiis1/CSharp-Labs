using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;

public interface IHdd : IHddBuilderDirector
{
    int Capacity { get; }
    int WorkSpeed { get; }
    int PowerConsumption { get; }
}