using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.EngineFuelExchange;

public class ImpulseEngineFuelExchange : IFuelExchange
{
    private const int FuelPrice = 12;
    public int CountingFlightCost(IFuel spentFuel)
    {
        return spentFuel.Fuel * FuelPrice;
    }
}