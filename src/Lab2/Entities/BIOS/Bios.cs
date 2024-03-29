using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class Bios : IBios
{
    public Bios(string type, int version, string supportedCpu)
    {
        Type = type;
        Version = version;
        SupportedCpu = supportedCpu;
    }

    public string Type { get; }
    public int Version { get; }
    public string SupportedCpu { get; }
    public IBuilderBios Direct(IBuilderBios biosBuilder)
    {
        biosBuilder.SetType(Type)
            .SetVersion(Version)
            .SetSupportedCpu(SupportedCpu);

        return biosBuilder;
    }
}