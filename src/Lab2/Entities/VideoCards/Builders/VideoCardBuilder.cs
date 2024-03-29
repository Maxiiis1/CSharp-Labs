using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public class VideoCardBuilder : IVideoCardBuilder
{
    private FormFactor? FormFactor { get; set; }
    private int MemorySize { get; set; }
    private int PciVersion { get; set; }
    private int ChipFrequancy { get; set; }
    private int PowerConcumption { get; set; }

    public IVideoCardBuilder SetFormFactor(FormFactor formFactor)
    {
        FormFactor = formFactor;
        return this;
    }

    public IVideoCardBuilder SetMemorySize(int size)
    {
        MemorySize = size;
        return this;
    }

    public IVideoCardBuilder SetPciVersion(int version)
    {
        PciVersion = version;
        return this;
    }

    public IVideoCardBuilder SetChipFrequancy(int frequancy)
    {
        ChipFrequancy = frequancy;
        return this;
    }

    public IVideoCardBuilder SetPowerConsumption(int consumption)
    {
        PowerConcumption = consumption;
        return this;
    }

    public IVideoCard Build()
    {
        return new VideoCard(
            FormFactor ?? throw new ArgumentNullException(nameof(FormFactor)),
            MemorySize,
            PciVersion,
            ChipFrequancy,
            PowerConcumption);
    }
}