using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class FileRenameRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "file" && args[1] == "rename")
        {
            IFileSystemCommand command = new Rename(new FilePath(args[2]), args[3]);
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}