using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class ConnectRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "connect")
        {
            var flagHandler = new FileSystemModeHandler();
            IFileSystemCommand command = new Connect(new FilePath(args[1]), flagHandler.Handle(args));
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}