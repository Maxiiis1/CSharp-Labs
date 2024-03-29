using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;

public class GamingCoolerBuilderDirector : ICoolerBuilderDirector
{
    public ICpuCoolerBuilder Direct(ICpuCoolerBuilder coolerBuilder)
    {
        coolerBuilder
            .SetSupportedSockets(new List<string> { "Intel", "Ryzen" })
            .SetFormFactor(new FormFactor(20, 20))
            .SetMaxPtd(60);
        return coolerBuilder;
    }
}