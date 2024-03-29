using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class FileMoveRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "file" && args[1] == "move")
        {
            IFileSystemCommand command = new MoveFile(new FilePath(args[2]), new FilePath(args[3]));
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}