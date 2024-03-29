using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;

public class NitriteFog : IArea
{
    private readonly IObstacle _obstacle;
    public NitriteFog(int distance, INitriteFogObstacle obstacle)
    {
        _obstacle = obstacle;
        Distance = distance;
    }

    public int Distance { get; }

    public PathResults PathResult(ISpaceShip spaceShip)
    {
        PathResults pathResult = _obstacle.DealDamage(spaceShip);
        if (pathResult != new PathResults.Success())
        {
            return pathResult;
        }

        IFuel fuelAmount = spaceShip.Engine.AreaPassing(Distance).Fuel;
        int time = spaceShip.Engine.AreaPassing(Distance).Time;

        IReadOnlyCollection<IFuel> spentFuels = new List<IFuel> { fuelAmount, new JumpEngineFuel(0) };

        return new PathResults.SuccessPathResult(spentFuels, time);
    }
}