using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;

public class HeavyFog : IArea
{
    private readonly IObstacle _obstacle;
    public HeavyFog(int distance, IHeavyFogObstacle obstacle)
    {
        _obstacle = obstacle;
        Distance = distance;
    }

    public int Distance { get; }

    public PathResults PathResult(ISpaceShip spaceShip)
    {
        IFuel fuelAmount;
        int time;

        if (spaceShip is ISpaceShipWithJumpEngine shipWithJumpEngine)
        {
            fuelAmount = shipWithJumpEngine.JumpEngine.AreaPassing(Distance).Fuel;
            time = shipWithJumpEngine.JumpEngine.AreaPassing(Distance).Time;
        }
        else
        {
            return new PathResults.ShipWasLost();
        }

        if (time == 0)
        {
            return new PathResults.ShipWasLost();
        }

        PathResults pathResult = _obstacle.DealDamage(spaceShip);
        if (pathResult != new PathResults.Success())
        {
            return pathResult;
        }

        IReadOnlyCollection<IFuel> spentFuels = new List<IFuel> { new ImpulseEngineFuel(0), fuelAmount };

        return new PathResults.SuccessPathResult(spentFuels, time);
    }
}