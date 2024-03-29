namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;

public interface IMotherBoardBuilderDirector
{
    IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder);
}