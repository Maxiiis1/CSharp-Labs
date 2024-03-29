using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class FileDeleteRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "file" && args[1] == "delete")
        {
            IFileSystemCommand command = new Delete(new FilePath(args[2]));
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}