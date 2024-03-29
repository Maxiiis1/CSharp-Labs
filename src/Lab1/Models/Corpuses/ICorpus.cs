using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Corpuses;

public interface ICorpus
{
    DamageResult TakeDamage(int damage);
}