using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;

public interface IRamBuilder
{
    IRamBuilder SetMemorySize(int memorySize);
    IRamBuilder SetJedec(JedecStandart jedec);
    IRamBuilder SetXmpProfiles(IReadOnlyCollection<IXmpProfile> xmpProfiles);
    IRamBuilder SetFormFactor(FormFactor formFactor);
    IRamBuilder SetDdrVersion(int ddrVersion);
    IRamBuilder SetPowerConsumpion(int powerConsumption);
    IRam Build();
}