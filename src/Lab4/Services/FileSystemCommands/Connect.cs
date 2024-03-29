using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class Connect : IFileSystemCommand
{
    private readonly FilePath _address;
    private readonly string _mode;

    public Connect(FilePath address, IReadOnlyDictionary<string, string> flags)
    {
        _address = address;
        _mode = flags.Count != 0 ? flags["fileSystemMode"] : "local";
    }

    public string Address => _address.Path;
    public string Mode => _mode;

    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        fileSystemProvider.SupportedFileSystems.TryGetValue(_mode, out IFileSystem? fileSystem);
        if (fileSystem != null)
        {
            fileSystemProvider.ChangeFileSystem(fileSystem);
            fileSystemProvider.AbsolutePath = _address;
            return new RequestResult.SuccessRequest();
        }

        return new RequestResult.RequestError("No supported file system");
    }
}