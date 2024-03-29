using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public interface IRam : IRamBuilderDirector
{
    int MemorySize { get; }
    JedecStandart SupportedJedec { get; }
    IReadOnlyCollection<IXmpProfile> SupportedXmp { get; }
    FormFactor FormFactor { get; }
    int DdrVersion { get; }
    int PowerConsumption { get; }
}