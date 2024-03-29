using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public abstract class RequestHandlerBase : IRequestHandler
{
    protected IRequestHandler? NextCommandHandler { get; private set; }

    public IRequestHandler SetNext(IRequestHandler requestHandler)
    {
        NextCommandHandler = requestHandler;
        return requestHandler;
    }

    public abstract IFileSystemCommand? Handle(string request);
}