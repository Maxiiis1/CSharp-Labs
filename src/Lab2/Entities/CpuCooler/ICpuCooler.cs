using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;

public interface ICpuCooler : ICoolerBuilderDirector
{
    FormFactor FormFactor { get; }
    int MaxTdp { get; }
    IReadOnlyCollection<string> SupportedSockets { get; }
}