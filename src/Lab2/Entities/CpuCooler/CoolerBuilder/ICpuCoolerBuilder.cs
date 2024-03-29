using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler.CoolerBuilder;

public interface ICpuCoolerBuilder
{
    ICpuCoolerBuilder SetFormFactor(FormFactor formFactor);
    ICpuCoolerBuilder SetMaxPtd(int maxTdp);
    ICpuCoolerBuilder SetSupportedSockets(IReadOnlyCollection<string> sockets);
    ICpuCooler Build();
}