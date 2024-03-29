namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

public interface ICpuBuilderDirector
{
    ICpuBuilder Direct(ICpuBuilder cpuBuilder);
}