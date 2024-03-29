using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.AreaValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class Gamma : IJumpEngine
{
    private const int FuelForStart = 100;
    private const int Speed = 50;

    public IFuel FuelAmounut { get; private set; } = new JumpEngineFuel(0);
    public AreaValues AreaPassing(int distance)
    {
        int time = distance / Speed;
        int consumption = (int)Math.Pow(distance, 2);
        var fuelAmount = new JumpEngineFuel(consumption + FuelForStart);

        return new AreaValues(fuelAmount, time);
    }
}