using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class Ram : IRam
{
    public Ram(
        int memorySize,
        JedecStandart supportedJedec,
        IReadOnlyCollection<IXmpProfile> supportedXmp,
        FormFactor formFactor,
        int ddrVersion,
        int powerConsumption)
    {
        MemorySize = memorySize;
        SupportedJedec = supportedJedec;
        SupportedXmp = supportedXmp;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public int MemorySize { get; }
    public JedecStandart SupportedJedec { get; }
    public IReadOnlyCollection<IXmpProfile> SupportedXmp { get; }
    public FormFactor FormFactor { get; }
    public int DdrVersion { get; }
    public int PowerConsumption { get; }
    public IRamBuilder Direct(IRamBuilder ramBuilder)
    {
        ramBuilder.SetJedec(SupportedJedec)
            .SetFormFactor(FormFactor)
            .SetMemorySize(MemorySize)
            .SetDdrVersion(DdrVersion)
            .SetPowerConsumpion(PowerConsumption)
            .SetXmpProfiles(SupportedXmp);
        return ramBuilder;
    }
}