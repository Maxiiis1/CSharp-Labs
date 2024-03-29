using Itmo.ObjectOrientedProgramming.Lab1.Models.HitPoint;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

public class PhotonicDeflector : IPhotonicDeflector
{
    private const int DeflectorHealth = 100;
    private readonly IDeflector _deflectorType;
    public PhotonicDeflector(IDeflector deflector)
    {
        _deflectorType = deflector;
    }

    public HitPoints HitPoints { get; set; } = new HitPoints(DeflectorHealth);
    public DamageResult TakeDamage(int damage)
    {
        return _deflectorType.TakeDamage(damage);
    }

    public DamageResult TakePhotonicDamage(int damage)
    {
        int remainingDamage = HitPoints.Health - damage;
        HitPoints = HitPoints.Subtract(HitPoints, damage);
        if (HitPoints.Health == 0)
        {
            return new DamageResult.RemainingDamage(remainingDamage);
        }

        return new DamageResult.Success();
    }
}