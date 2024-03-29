using System;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;

public class CpuBuilder : ICpuBuilder
{
    private int Frequancy { get; set; }
    private int CoresCount { get; set; }
    private string? Socket { get; set; }
    private bool IntegratedVideoCore { get; set; }
    private int SupportedMemoryFrequencies { get; set; }
    private int Tdp { get; set; }
    private int PowerConsumption { get; set; }
    private string? Model { get; set; }

    public ICpuBuilder SetModel(string model)
    {
        Model = model;
        return this;
    }

    public ICpuBuilder SetCoreFrequancy(int frequancy)
    {
        Frequancy = frequancy;
        return this;
    }

    public ICpuBuilder SetCoresCount(int count)
    {
        CoresCount = count;
        return this;
    }

    public ICpuBuilder SetSocket(string socket)
    {
        Socket = socket;
        return this;
    }

    public ICpuBuilder SetVideoCore(bool integratedVideoCore)
    {
        IntegratedVideoCore = integratedVideoCore;
        return this;
    }

    public ICpuBuilder SetMemoryFrequencies(int frequancies)
    {
        SupportedMemoryFrequencies = frequancies;
        return this;
    }

    public ICpuBuilder SetTdp(int tdp)
    {
        Tdp = tdp;
        return this;
    }

    public ICpuBuilder SetPowerConsumption(int consumption)
    {
        PowerConsumption = consumption;
        return this;
    }

    public ICpu Build()
    {
        return new Cpu(
            Model ?? throw new ArgumentNullException(nameof(Model)),
            Frequancy,
            CoresCount,
            Socket ?? throw new ArgumentNullException(nameof(Socket)),
            IntegratedVideoCore,
            SupportedMemoryFrequencies,
            Tdp,
            PowerConsumption);
    }
}