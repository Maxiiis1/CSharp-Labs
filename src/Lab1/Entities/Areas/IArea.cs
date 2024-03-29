using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;

public interface IArea
{
    int Distance { get; }
    PathResults PathResult(ISpaceShip spaceShip);
}