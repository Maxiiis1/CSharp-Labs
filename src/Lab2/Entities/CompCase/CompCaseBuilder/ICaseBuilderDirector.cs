namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;

public interface ICaseBuilderDirector
{
    ICaseBuilder Direct(ICaseBuilder caseBuilder);
}