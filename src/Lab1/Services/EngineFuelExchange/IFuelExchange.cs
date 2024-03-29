using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.EngineFuelExchange;

public interface IFuelExchange
{
    int CountingFlightCost(IFuel spentFuel);
}