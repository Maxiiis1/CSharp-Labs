using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.EngineFuelExchange;

public class JumpEngineFuelExchange : IFuelExchange
{
    private const int FuelPrice = 24;
    public int CountingFlightCost(IFuel spentFuel)
    {
        return spentFuel.Fuel * FuelPrice;
    }
}