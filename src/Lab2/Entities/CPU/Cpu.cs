using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class Cpu : ICpu
{
    public Cpu(string model, int frequancy, int coresCount, string socket, bool integratedVideoCore, int supportedMemory, int tdp, int powerConsumption)
    {
        Model = model;
        Frequancy = frequancy;
        CoresCount = coresCount;
        Socket = socket;
        IntegratedVideoCore = integratedVideoCore;
        SupportedMemoryFrequencies = supportedMemory;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }
    public int Frequancy { get; }
    public int CoresCount { get; }
    public string Socket { get; }
    public bool IntegratedVideoCore { get; }
    public int SupportedMemoryFrequencies { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }
    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        cpuBuilder.SetModel(Model)
            .SetSocket(Socket)
            .SetTdp(Tdp)
            .SetCoresCount(CoresCount)
            .SetCoreFrequancy(Frequancy)
            .SetVideoCore(IntegratedVideoCore)
            .SetPowerConsumption(PowerConsumption)
            .SetMemoryFrequencies(SupportedMemoryFrequencies);
        return cpuBuilder;
    }
}