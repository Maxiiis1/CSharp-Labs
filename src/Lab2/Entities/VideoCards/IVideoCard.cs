using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCard : IVideoCardBuilderDirector
{
    FormFactor FormFactor { get; }
    int MemorySize { get; }
    int PciVersion { get; }
    int ChipFrequancy { get; }
    int PowerConcumption { get; }
}