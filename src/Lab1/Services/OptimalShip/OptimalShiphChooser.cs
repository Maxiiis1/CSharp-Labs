using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.ValueCounter;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShip;

public class OptimalShiphChooser : IOptimalShiphChooser
{
    private readonly List<IArea> _areas;
    public OptimalShiphChooser(params IArea[] areas)
    {
        _areas = areas.ToList();
    }

    public ISpaceShip GetOptimalShip(ISpaceShip firstSpaceShip, ISpaceShip secondSpaceShip)
    {
        var counter1 = new Counter(firstSpaceShip);
        var counter2 = new Counter(secondSpaceShip);
        int spentFuelAmount1 = counter1.CountingFuelCost(_areas);
        int spentFuelAmount2 = counter2.CountingFuelCost(_areas);

        if (spentFuelAmount1 > spentFuelAmount2)
        {
            return secondSpaceShip;
        }

        return firstSpaceShip;
    }
}