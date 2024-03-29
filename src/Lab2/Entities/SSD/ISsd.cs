using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public interface ISsd : ISsdBuilderDirector
{
    string ConnectionType { get; }
    int Capacity { get; }
    int WorkSpeed { get; }
    int PowerConsumption { get; }
}