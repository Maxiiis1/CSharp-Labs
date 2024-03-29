using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;

public class Cooler : ICpuCooler
{
    public Cooler(FormFactor formFactor, int maxTdp, IReadOnlyCollection<string> supportedSockets)
    {
        FormFactor = formFactor;
        MaxTdp = maxTdp;
        SupportedSockets = supportedSockets;
    }

    public FormFactor FormFactor { get; }
    public int MaxTdp { get; }
    public IReadOnlyCollection<string> SupportedSockets { get; }
    public ICpuCoolerBuilder Direct(ICpuCoolerBuilder coolerBuilder)
    {
        coolerBuilder
            .SetSupportedSockets(SupportedSockets)
            .SetFormFactor(FormFactor)
            .SetMaxPtd(60);
        return coolerBuilder;
    }
}