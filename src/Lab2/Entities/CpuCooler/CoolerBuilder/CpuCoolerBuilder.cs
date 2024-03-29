using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;

public class CpuCoolerBuilder : ICpuCoolerBuilder
{
    private FormFactor? FormFactor { get; set; }
    private int MaxTdp { get; set; }
    private IReadOnlyCollection<string>? SupportedSockets { get; set; }

    public ICpuCoolerBuilder SetFormFactor(FormFactor formFactor)
    {
        FormFactor = formFactor;
        return this;
    }

    public ICpuCoolerBuilder SetMaxPtd(int maxTdp)
    {
        MaxTdp = maxTdp;
        return this;
    }

    public ICpuCoolerBuilder SetSupportedSockets(IReadOnlyCollection<string> sockets)
    {
        SupportedSockets = sockets;
        return this;
    }

    public ICpuCoolerBuilder SetComponents(ICpuCooler cooler)
    {
        FormFactor = cooler.FormFactor;
        MaxTdp = cooler.MaxTdp;
        SupportedSockets = cooler.SupportedSockets;
        return this;
    }

    public ICpuCooler Build()
    {
        return new Cooler(
            FormFactor ?? throw new ArgumentNullException(),
            MaxTdp,
            SupportedSockets ?? throw new ArgumentNullException());
    }
}