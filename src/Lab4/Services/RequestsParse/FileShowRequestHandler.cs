using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.RequestsParse;

public class FileShowRequestHandler : RequestHandlerBase
{
    public override IFileSystemCommand? Handle(string request)
    {
        string[] args = request.Split(' ');
        if (args[0] == "file" && args[1] == "show")
        {
            var flagHandler = new ShowModeHandler();
            IFileSystemCommand command = new ShowFileContent(new FilePath(args[2]), flagHandler.Handle(args));
            return command;
        }

        return NextCommandHandler?.Handle(request);
    }
}