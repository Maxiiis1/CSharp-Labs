using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Path;

public interface ISpacePath
{
    PathResults PathResult(ISpaceShip spaceShip);
}