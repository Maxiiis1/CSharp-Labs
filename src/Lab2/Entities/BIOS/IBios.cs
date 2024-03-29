using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public interface IBios : IBiosBuilderDirector
{
    string Type { get; }
    int Version { get; }
    string SupportedCpu { get; }
}