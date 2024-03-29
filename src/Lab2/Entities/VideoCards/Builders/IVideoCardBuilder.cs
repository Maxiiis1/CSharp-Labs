using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public interface IVideoCardBuilder
{
    IVideoCardBuilder SetFormFactor(FormFactor formFactor);
    IVideoCardBuilder SetMemorySize(int size);
    IVideoCardBuilder SetPciVersion(int version);
    IVideoCardBuilder SetChipFrequancy(int frequancy);
    IVideoCardBuilder SetPowerConsumption(int consumption);
    IVideoCard Build();
}