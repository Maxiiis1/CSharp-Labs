using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.SataPort;

public class SataPorts : ISataPorts
{
    public SataPorts(IHdd[] hdds, ISsd[] ssds)
    {
        ConnectedHdd = hdds.ToList();
        ConnectedSSd = ssds.ToList();
    }

    public IReadOnlyCollection<IHdd> ConnectedHdd { get; }
    public IReadOnlyCollection<ISsd> ConnectedSSd { get; }
}