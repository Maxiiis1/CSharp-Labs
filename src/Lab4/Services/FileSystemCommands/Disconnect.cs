using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class Disconnect : IFileSystemCommand
{
    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        fileSystemProvider.ChangeFileSystem(new DisconnectedFileSystem());
        return new RequestResult.SuccessRequest();
    }
}