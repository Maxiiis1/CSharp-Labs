using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public interface IObstacle
{
    PathResults DealDamage(ISpaceShip ship);
}