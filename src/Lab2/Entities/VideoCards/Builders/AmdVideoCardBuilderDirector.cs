using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public class AmdVideoCardBuilderDirector : IVideoCardBuilderDirector
{
    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder.SetFormFactor(new FormFactor(22, 5))
            .SetChipFrequancy(1500)
            .SetPowerConsumption(150)
            .SetMemorySize(4)
            .SetChipFrequancy(3);
        return videoCardBuilder;
    }
}