namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

public interface IXmpBuilderDirector
{
    IXmpBuilder Direct(IXmpBuilder xmpBuilder);
}