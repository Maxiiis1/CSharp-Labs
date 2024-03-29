using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public interface ICpu : ICpuBuilderDirector
{
    string Model { get; }
    int Frequancy { get; }
    int CoresCount { get; }
    string Socket { get; }
    bool IntegratedVideoCore { get; }
    int SupportedMemoryFrequencies { get; }
    int Tdp { get; }
    int PowerConsumption { get; }
}