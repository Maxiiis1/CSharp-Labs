using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.AreaValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class PulseEngineC : IEngine
{
    private const int Speed = 30;

    public IFuel FuelAmounut { get; private set; } = new ImpulseEngineFuel(0);
    public AreaValues AreaPassing(int distance)
    {
        int time = distance / Speed;
        var fuelAmount = new ImpulseEngineFuel(distance);

        return new AreaValues(fuelAmount, time);
    }
}