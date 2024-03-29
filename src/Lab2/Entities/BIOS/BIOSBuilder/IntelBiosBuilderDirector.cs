namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

public class IntelBiosBuilderDirector : IBiosBuilderDirector
{
    public IBuilderBios Direct(IBuilderBios biosBuilder)
    {
        biosBuilder
            .SetType("UEFI")
            .SetVersion(1)
            .SetSupportedCpu("Intel");
        return biosBuilder;
    }
}