namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

public interface ICpuBuilder
{
    ICpuBuilder SetModel(string model);
    ICpuBuilder SetCoreFrequancy(int frequancy);
    ICpuBuilder SetCoresCount(int count);
    ICpuBuilder SetSocket(string socket);
    ICpuBuilder SetVideoCore(bool integratedVideoCore);
    ICpuBuilder SetMemoryFrequencies(int frequancies);
    ICpuBuilder SetTdp(int tdp);
    ICpuBuilder SetPowerConsumption(int consumption);
    ICpu Build();
}