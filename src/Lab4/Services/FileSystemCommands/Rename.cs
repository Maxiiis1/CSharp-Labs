using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class Rename : IFileSystemCommand
{
    private readonly string _name;
    private readonly FilePath _path;

    public Rename(FilePath path, string name)
    {
        _name = name;
        _path = path;
    }

    public string Path => _path.Path;
    public string Name => _name;

    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        string pathValidationResult = fileSystemProvider.PathValidator.Validate(fileSystemProvider.AbsolutePath.Path, fileSystemProvider.RelativePath.Path, _path.Path);
        if (!string.IsNullOrEmpty(pathValidationResult))
        {
            return fileSystemProvider.CurrentFileSystem.RenameFile(new FilePath(pathValidationResult), _name);
        }

        return new RequestResult.RequestError("Wrong path!");
    }
}