using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

public class BiosBuilder : IBuilderBios
{
    private string? Type { get; set; }
    private int Version { get; set; }
    private string? SupportedCpu { get; set; }

    public IBuilderBios SetType(string type)
    {
        Type = type;
        return this;
    }

    public IBuilderBios SetVersion(int version)
    {
        Version = version;
        return this;
    }

    public IBuilderBios SetSupportedCpu(string supportedCpu)
    {
        SupportedCpu = supportedCpu;
        return this;
    }

    public IBuilderBios SetComponents(IBios bios)
    {
        SupportedCpu = bios.SupportedCpu;
        Type = bios.Type;
        Version = bios.Version;
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            Type ?? throw new ArgumentNullException(),
            Version,
            SupportedCpu ?? throw new ArgumentNullException());
    }
}