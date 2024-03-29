using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;

public class RyzenSocket : ICpuSocket
{
    public RyzenSocket(ICpu cpu)
    {
        ConnectedCpu = cpu;
    }

    public ICpu ConnectedCpu { get; }
}