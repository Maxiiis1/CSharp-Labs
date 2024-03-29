using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;

public class RamBuilder : IRamBuilder
{
    private int MemorySize { get; set; }
    private JedecStandart? SupportedJedec { get; set; }
    private IReadOnlyCollection<IXmpProfile>? SupportedXmp { get; set; }
    private FormFactor? FormFactor { get; set; }
    private int DdrVersion { get; set; }
    private int PowerConsumption { get; set; }

    public IRamBuilder SetMemorySize(int memorySize)
    {
        MemorySize = memorySize;
        return this;
    }

    public IRamBuilder SetJedec(JedecStandart jedec)
    {
        SupportedJedec = jedec;
        return this;
    }

    public IRamBuilder SetXmpProfiles(IReadOnlyCollection<IXmpProfile> xmpProfiles)
    {
        SupportedXmp = xmpProfiles;
        return this;
    }

    public IRamBuilder SetFormFactor(FormFactor formFactor)
    {
        FormFactor = formFactor;
        return this;
    }

    public IRamBuilder SetDdrVersion(int ddrVersion)
    {
        DdrVersion = ddrVersion;
        return this;
    }

    public IRamBuilder SetPowerConsumpion(int powerConsumption)
    {
        PowerConsumption = powerConsumption;
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            MemorySize,
            SupportedJedec ?? throw new ArgumentNullException(),
            SupportedXmp ?? throw new ArgumentNullException(nameof(SupportedXmp)),
            FormFactor ?? throw new ArgumentNullException(),
            DdrVersion,
            PowerConsumption);
    }
}