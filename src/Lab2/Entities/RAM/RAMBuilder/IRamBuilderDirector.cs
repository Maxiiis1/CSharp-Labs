namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM.RAMBuilder;

public interface IRamBuilderDirector
{
    IRamBuilder Direct(IRamBuilder ramBuilder);
}