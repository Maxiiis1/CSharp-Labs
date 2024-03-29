namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD.HDDBuilder;

public interface IHddBuilderDirector
{
    IHddBuilder Direct(IHddBuilder hddBuilder);
}