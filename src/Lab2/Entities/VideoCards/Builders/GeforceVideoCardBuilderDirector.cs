using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public class GeforceVideoCardBuilderDirector : IVideoCardBuilderDirector
{
    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder.SetFormFactor(new FormFactor(25, 6))
            .SetChipFrequancy(1900)
            .SetPowerConsumption(200)
            .SetMemorySize(8)
            .SetChipFrequancy(4);
        return videoCardBuilder;
    }
}