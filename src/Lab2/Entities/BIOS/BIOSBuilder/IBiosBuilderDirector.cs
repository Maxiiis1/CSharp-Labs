namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS.BIOSBuilder;

public interface IBiosBuilderDirector
{
    IBuilderBios Direct(IBuilderBios biosBuilder);
}