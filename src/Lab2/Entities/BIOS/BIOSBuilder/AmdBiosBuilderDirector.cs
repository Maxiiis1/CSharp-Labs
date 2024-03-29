namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

public class AmdBiosBuilderDirector : IBiosBuilderDirector
{
    public IBuilderBios Direct(IBuilderBios biosBuilder)
    {
        biosBuilder
            .SetType("UEFI")
            .SetVersion(1)
            .SetSupportedCpu("Ryzen");
        return biosBuilder;
    }
}