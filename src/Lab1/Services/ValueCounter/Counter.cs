using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.EngineFuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ValueCounter;

public class Counter
{
    private readonly ISpaceShip _spaceShip;
    private readonly ImpulseEngineFuelExchange _impulseEngineFuelExchange = new ImpulseEngineFuelExchange();
    private readonly JumpEngineFuelExchange _jumpEngineFuelExchange = new JumpEngineFuelExchange();
    public Counter(ISpaceShip spaceShip)
    {
        _spaceShip = spaceShip;
    }

    public int CountingFuelCost(IReadOnlyCollection<IArea> areas)
    {
        int spentMoney = 0;
        var path = new SpacePath(areas.ToArray());

        // Act
        PathResults result = path.PathResult(_spaceShip);

        if (result is PathResults.SuccessPathResult values)
        {
            foreach (IFuel fuel in values.SpentFuel)
            {
                if (fuel is JumpEngineFuel)
                {
                    spentMoney += _jumpEngineFuelExchange.CountingFlightCost(fuel);
                }
                else if (fuel is ImpulseEngineFuel)
                {
                    spentMoney += _impulseEngineFuelExchange.CountingFlightCost(fuel);
                }
            }
        }

        return spentMoney;
    }
}