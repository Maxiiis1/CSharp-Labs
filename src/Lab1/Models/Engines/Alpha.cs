using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.AreaValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class Alpha : IJumpEngine
{
    private const int FuelForStart = 100;
    private const int Speed = 50;
    private const int MediumDistance = 400;

    public IFuel FuelAmounut { get; private set; } = new JumpEngineFuel(0);

    public AreaValues AreaPassing(int distance)
    {
        if (distance > MediumDistance)
        {
            return new AreaValues(new JumpEngineFuel(0), 0);
        }

        int time = distance / Speed;
        var fuelAmount = new JumpEngineFuel(distance + FuelForStart);

        return new AreaValues(fuelAmount, time);
    }
}