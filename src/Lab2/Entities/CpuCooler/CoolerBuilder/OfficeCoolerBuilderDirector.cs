using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;

public class OfficeCoolerBuilderDirector : ICoolerBuilderDirector
{
    public ICpuCoolerBuilder Direct(ICpuCoolerBuilder coolerBuilder)
    {
        coolerBuilder
            .SetSupportedSockets(new List<string> { "Intel", "Ryzen" })
            .SetFormFactor(new FormFactor(12, 12))
            .SetMaxPtd(40);
        return coolerBuilder;
    }
}