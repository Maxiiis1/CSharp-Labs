using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;

public interface ICpuSocket
{
    ICpu ConnectedCpu { get; }
}