using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class GoToRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "tree" && args[1] == "goto")
        {
            IFileSystemCommand command = new GoToCommand(new FilePath(args[2]));
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}