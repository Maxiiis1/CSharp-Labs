using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public interface IXmpProfile : IXmpBuilderDirector
{
    IReadOnlyCollection<int> Timings { get; }
    double SupportedVoltage { get; }
    int Frequancy { get; }
}