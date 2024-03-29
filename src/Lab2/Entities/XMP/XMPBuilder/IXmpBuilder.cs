using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

public interface IXmpBuilder
{
    IXmpBuilder SetTimings(IReadOnlyCollection<int> timings);
    IXmpBuilder SetVoltage(double voltage);
    IXmpBuilder SetFrequancy(int frequancy);
    IXmpProfile Build();
}