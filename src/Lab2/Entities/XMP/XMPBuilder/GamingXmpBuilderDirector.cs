using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

public class GamingXmpBuilderDirector : IXmpBuilderDirector
{
    public IXmpBuilder Direct(IXmpBuilder xmpBuilder)
    {
        xmpBuilder.SetFrequancy(4000)
            .SetTimings(new List<int> { 12, 12, 12, 24 })
            .SetVoltage(1.35);
        return xmpBuilder;
    }
}