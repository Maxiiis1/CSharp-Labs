namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

public class IntelCpuBuilderDirector : ICpuBuilderDirector
{
    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        cpuBuilder
            .SetModel("Intel")
            .SetSocket("Intel")
            .SetTdp(40)
            .SetCoresCount(4)
            .SetCoreFrequancy(3)
            .SetVideoCore(true)
            .SetPowerConsumption(150)
            .SetMemoryFrequencies(3500);
        return cpuBuilder;
    }
}