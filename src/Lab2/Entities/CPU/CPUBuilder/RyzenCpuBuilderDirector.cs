namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

public class RyzenCpuBuilderDirector : ICpuBuilderDirector
{
    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        cpuBuilder
            .SetModel("Ryzen")
            .SetSocket("Ryzen")
            .SetTdp(20)
            .SetCoresCount(2)
            .SetCoreFrequancy(3)
            .SetVideoCore(false)
            .SetPowerConsumption(100)
            .SetMemoryFrequencies(2000);
        return cpuBuilder;
    }
}