using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.AreaValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class PulseEngineE : IEngine
{
    private const int FuelForStart = 100;
    private const int Speed = 4;

    public IFuel FuelAmounut { get; private set; } = new ImpulseEngineFuel(0);
    public AreaValues AreaPassing(int distance)
    {
        int speed = (int)Math.Exp(Speed);
        int time = distance / speed;
        int consumption = distance * 3;
        var fuelAmount = new ImpulseEngineFuel(consumption + FuelForStart);

        return new AreaValues(fuelAmount, time);
    }
}