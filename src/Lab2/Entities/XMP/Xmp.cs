using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public class Xmp : IXmpProfile
{
    public Xmp(IReadOnlyCollection<int> timings, double supportedVoltage, int frequancy)
    {
        Timings = timings;
        SupportedVoltage = supportedVoltage;
        Frequancy = frequancy;
    }

    public IReadOnlyCollection<int> Timings { get; }
    public double SupportedVoltage { get; }
    public int Frequancy { get; }
    public IXmpBuilder Direct(IXmpBuilder xmpBuilder)
    {
        xmpBuilder.SetFrequancy(Frequancy)
            .SetTimings(Timings)
            .SetVoltage(SupportedVoltage);
        return xmpBuilder;
    }
}