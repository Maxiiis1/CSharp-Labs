using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class SpaceWhale : INitriteFogObstacle
{
    private const int Damage = 460;
    private int _amount;
    public SpaceWhale(int amount)
    {
        _amount = amount;
    }

    public PathResults DealDamage(ISpaceShip ship)
    {
        DamageResult result;
        if (ship is ISpaceShipWithDeflector shipWithDeflector)
        {
            if (shipWithDeflector is ISpaceShipWithEmitter)
            {
                result = shipWithDeflector.Deflector.TakeDamage((int)(Damage * 0.3) * _amount);
                if (result is DamageResult.RemainingDamage damageResult)
                {
                    if (ship.Corpus.TakeDamage(damageResult.Damage) != new DamageResult.Success())
                    {
                        return new PathResults.ShipWasDestroyed();
                    }
                }

                return new PathResults.Success();
            }
            else
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
        }

        return new PathResults.ShipWasDestroyed();
    }
}