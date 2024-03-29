using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.AreaValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public interface IJumpEngine
{
    IFuel FuelAmounut { get; }
    AreaValues AreaPassing(int distance);
}