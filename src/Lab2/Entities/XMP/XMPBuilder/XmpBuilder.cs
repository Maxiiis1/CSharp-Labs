using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

public class XmpBuilder : IXmpBuilder
{
    private IReadOnlyCollection<int>? Timings { get; set; }
    private double SupportedVoltage { get; set; }
    private int Frequancy { get; set; }

    public IXmpBuilder SetTimings(IReadOnlyCollection<int> timings)
    {
        Timings = timings;
        return this;
    }

    public IXmpBuilder SetVoltage(double voltage)
    {
        SupportedVoltage = voltage;
        return this;
    }

    public IXmpBuilder SetFrequancy(int frequancy)
    {
        Frequancy = frequancy;
        return this;
    }

    public IXmpProfile Build()
    {
        return new Xmp(
            Timings ?? throw new ArgumentNullException(),
            SupportedVoltage,
            Frequancy);
    }
}