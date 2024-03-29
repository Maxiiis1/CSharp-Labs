using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;

public abstract record PathResults
{
    private PathResults() { }
    public sealed record Success : PathResults;
    public sealed record SuccessPathResult(IReadOnlyCollection<IFuel> SpentFuel, int Hours) : PathResults;
    public sealed record ShipWasLost : PathResults;
    public sealed record ShipWasDestroyed : PathResults;
    public sealed record PassengersWereDied : PathResults;
}