using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class Meteor : ISpaceObstacle
{
    private const int Damage = 15;
    private readonly int _amount;
    public Meteor(int amount)
    {
        _amount = amount;
    }

    public PathResults DealDamage(ISpaceShip ship)
    {
        DamageResult result;
        if (ship is ISpaceShipWithDeflector shipWithDeflector)
        {
            result = shipWithDeflector.Deflector.TakeDamage(Damage * _amount);
            if (result is DamageResult.RemainingDamage damageResult)
            {
                if (ship.Corpus.TakeDamage(damageResult.Damage) != new DamageResult.Success())
                {
                    return new PathResults.ShipWasDestroyed();
                }
            }

            return new PathResults.Success();
        }

        result = ship.Corpus.TakeDamage(Damage * _amount);
        if (result != new DamageResult.Success())
        {
            return new PathResults.ShipWasDestroyed();
        }

        return new PathResults.Success();
    }
}
