namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

public interface IBuilderBios
{
    IBuilderBios SetType(string type);
    IBuilderBios SetVersion(int version);
    IBuilderBios SetSupportedCpu(string supportedCpu);
    IBios Build();
}