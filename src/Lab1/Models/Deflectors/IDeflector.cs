using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

public interface IDeflector
{
    DamageResult TakeDamage(int damage);
}