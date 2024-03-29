using Itmo.ObjectOrientedProgramming.Lab1.Models.HitPoint;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

public class Deflector2Class : IDeflector
{
    private const int DeflectorHealth = 100;
    public HitPoints HitPoints { get; set;  } = new(DeflectorHealth);

    public DamageResult TakeDamage(int damage)
    {
        int fullDamage = (int)(damage * 1.05);
        int remainingDamage = HitPoints.Health - fullDamage;
        HitPoints = HitPoints.Subtract(HitPoints, fullDamage);
        if (HitPoints.Health == 0)
        {
            return new DamageResult.RemainingDamage(remainingDamage);
        }

        return new DamageResult.Success();
    }
}