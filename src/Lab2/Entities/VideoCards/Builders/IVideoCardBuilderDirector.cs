namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public interface IVideoCardBuilderDirector
{
    IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder);
}