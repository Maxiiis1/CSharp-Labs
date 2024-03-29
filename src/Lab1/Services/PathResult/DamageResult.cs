namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

public abstract record DamageResult
{
    private DamageResult() { }

    public sealed record Success() : DamageResult;
    public sealed record ShipWasDestroyed : DamageResult;
    public sealed record RemainingDamage(int Damage) : DamageResult;
}