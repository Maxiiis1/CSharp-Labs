using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class AntimatterFlare : IHeavyFogObstacle
{
    private const int Damage = 40;
    private readonly int _amount;
    public AntimatterFlare(int amount)
    {
        _amount = amount;
    }

    public PathResults DealDamage(ISpaceShip ship)
    {
        if (ship is ISpaceShipWithDeflector spaceShip)
        {
            if (spaceShip.Deflector is IPhotonicDeflector photonicDeflector)
            {
                DamageResult result = photonicDeflector.TakePhotonicDamage(Damage * _amount);
                if (result is DamageResult.RemainingDamage damageResult)
                {
                    if (ship.Corpus.TakeDamage(damageResult.Damage) != new DamageResult.Success())
                    {
                        return new PathResults.PassengersWereDied();
                    }
                }
            }
            else
            {
                return new PathResults.PassengersWereDied();
            }
        }
        else
        {
            return new PathResults.PassengersWereDied();
        }

        return new PathResults.Success();
    }
}
