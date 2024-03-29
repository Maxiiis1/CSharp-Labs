using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoriesSymbols;
using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoryVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class TreeList : IFileSystemCommand
{
    private readonly string _depth;

    public TreeList(IReadOnlyDictionary<string, string> flags)
    {
        _depth = flags.Count != 0 ? flags["depth"] : "1";
    }

    public string Depth => _depth;

    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        if (fileSystemProvider.CurrentFileSystem is DisconnectedFileSystem)
        {
            return new RequestResult.RequestError("File system was disconnected");
        }

        if (int.TryParse(_depth, out int intValue))
        {
            if (fileSystemProvider.CurrentFileSystem.TreeList(fileSystemProvider.AbsolutePath, intValue) is
                RequestResult.SuccessTreeRequest content)
            {
                IDirectoryVisitor visitor =
                    new DirectoryVisitor(new ConsoleStrategy(), new DirectorySymbols("D ", "F "));
                visitor.VisitDirectory(content.Directory);
            }
        }

        return new RequestResult.SuccessRequest();
    }
}