namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD.SSDBuilder;

public interface ISsdBuilderDirector
{
    ISsdBuilder Direct(ISsdBuilder ssdBuilder);
}