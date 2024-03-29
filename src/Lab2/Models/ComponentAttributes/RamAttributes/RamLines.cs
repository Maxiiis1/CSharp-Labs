using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.RamAttributes;

public class RamLines : IRamLines
{
    public RamLines(params IRam[] rams)
    {
        ConnectedRams = rams.ToList();
    }

    public IReadOnlyCollection<IRam> ConnectedRams { get; }
}