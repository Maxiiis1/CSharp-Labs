using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;

public class IntelSocket : ICpuSocket
{
    public IntelSocket(ICpu cpu)
    {
        ConnectedCpu = cpu;
    }

    public ICpu ConnectedCpu { get; }
}