using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public class VideoCard : IVideoCard
{
    public VideoCard(FormFactor formFactor, int memorySize, int pciVersion, int chipFrequancy, int powerConcumption)
    {
        FormFactor = formFactor;
        MemorySize = memorySize;
        PciVersion = pciVersion;
        ChipFrequancy = chipFrequancy;
        PowerConcumption = powerConcumption;
    }

    public FormFactor FormFactor { get; set; }
    public int MemorySize { get; }
    public int PciVersion { get; }
    public int ChipFrequancy { get; }
    public int PowerConcumption { get; }
    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder.SetPowerConsumption(PowerConcumption)
            .SetFormFactor(FormFactor)
            .SetMemorySize(MemorySize)
            .SetChipFrequancy(ChipFrequancy)
            .SetPciVersion(PciVersion);
        return videoCardBuilder;
    }
}