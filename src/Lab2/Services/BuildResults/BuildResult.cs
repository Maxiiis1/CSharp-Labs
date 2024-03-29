using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;

public abstract record BuildResult
{
    private BuildResult() { }
    public sealed record Success : BuildResult;
    public sealed record SuccessBuild(IComputer Computer) : BuildResult;
    public sealed record ComponentsIncompatibility(string Problem) : BuildResult;
    public sealed record ResponsibilityRejection(string Problem) : BuildResult;
    public sealed record ComponentsLack(string Component) : BuildResult;
    public sealed record PassengersWereDied : BuildResult;
}