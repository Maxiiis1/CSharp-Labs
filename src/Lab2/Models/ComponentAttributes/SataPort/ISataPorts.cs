using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.SataPort;

public interface ISataPorts
{
    IReadOnlyCollection<IHdd> ConnectedHdd { get; }
    IReadOnlyCollection<ISsd> ConnectedSSd { get; }
}