using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.RamAttributes;

public interface IRamLines
{
    IReadOnlyCollection<IRam> ConnectedRams { get; }
}