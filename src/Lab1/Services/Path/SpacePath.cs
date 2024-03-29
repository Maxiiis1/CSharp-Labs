using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Path;

public class SpacePath : ISpacePath
{
    private readonly List<IArea> _areas;
    public SpacePath(params IArea[] areas)
    {
        _areas = areas.ToList();
    }

    public PathResults PathResult(ISpaceShip spaceShip)
    {
        PathResults pathResult;
        PathResults.SuccessPathResult values;
        int hours = 0;

        var fuels = new List<IFuel> { new ImpulseEngineFuel(0), new JumpEngineFuel(0) };

        foreach (IArea area in _areas)
        {
            pathResult = area.PathResult(spaceShip);

            if (pathResult == new PathResults.PassengersWereDied() || pathResult == new PathResults.ShipWasDestroyed() || pathResult == new PathResults.ShipWasLost())
            {
                return pathResult;
            }

            values = (PathResults.SuccessPathResult)pathResult;
            hours += values.Hours;
            for (int i = 0; i < values.SpentFuel.Count; i++)
            {
                fuels[i] = fuels[i].Summ(values.SpentFuel.ElementAt(i).Fuel);
            }
        }

        return new PathResults.SuccessPathResult(fuels.AsReadOnly(), hours);
    }
}