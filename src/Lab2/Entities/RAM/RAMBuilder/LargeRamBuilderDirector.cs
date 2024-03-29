using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;

public class LargeRamBuilderDirector : IRamBuilderDirector
{
    public IRamBuilder Direct(IRamBuilder ramBuilder)
    {
        ramBuilder.SetFormFactor(new FormFactor(13, 4))
            .SetMemorySize(64)
            .SetJedec(new JedecStandart(4000, 1.35))
            .SetDdrVersion(5)
            .SetPowerConsumpion(20)
            .SetXmpProfiles(new List<IXmpProfile> { new Xmp(new List<int> { 12, 12, 13, 14 }, 1.35, 4000) });
        return ramBuilder;
    }
}