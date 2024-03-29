using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public interface IRequestHandler
{
    IRequestHandler SetNext(IRequestHandler requestHandler);
    IFileSystemCommand? Handle(string request);
}