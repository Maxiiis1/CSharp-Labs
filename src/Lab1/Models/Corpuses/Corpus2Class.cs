using Itmo.ObjectOrientedProgramming.Lab1.Models.HitPoint;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Corpuses;

public class Corpus2Class : ICorpus
{
    private const int CorpusHealth = 200;
    public HitPoints HitPoints { get; set; } = new(CorpusHealth);
    public DamageResult TakeDamage(int damage)
    {
        int fullDamage = (int)(int.Abs(damage) * 1.8);
        HitPoints = HitPoints.Subtract(HitPoints, fullDamage);
        if (HitPoints.Health == 0)
        {
            return new DamageResult.ShipWasDestroyed();
        }

        return new DamageResult.Success();
    }
}