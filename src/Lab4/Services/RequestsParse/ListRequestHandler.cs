using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class ListRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "tree" && args[1] == "list")
        {
            var flagHandler = new TreeDepthFlagHandler();
            IFileSystemCommand command = new TreeList(flagHandler.Handle(args));
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}