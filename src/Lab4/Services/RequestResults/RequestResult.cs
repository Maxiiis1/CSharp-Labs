using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

public abstract record RequestResult
{
    private RequestResult() { }
    public sealed record SuccessRequest : RequestResult;
    public sealed record SuccessTreeRequest(FileDirectory Directory) : RequestResult;
    public sealed record RequestError(string Problem) : RequestResult;
}