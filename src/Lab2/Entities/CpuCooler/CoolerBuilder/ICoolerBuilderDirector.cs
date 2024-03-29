namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;

public interface ICoolerBuilderDirector
{
    ICpuCoolerBuilder Direct(ICpuCoolerBuilder coolerBuilder);
}