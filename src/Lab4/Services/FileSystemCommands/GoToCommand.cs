using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class GoToCommand : IFileSystemCommand
{
    private readonly FilePath _path;

    public GoToCommand(FilePath path)
    {
        _path = path;
    }

    public string Path => _path.Path;

    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        string pathValidationResult = fileSystemProvider.PathValidator.Validate(fileSystemProvider.AbsolutePath.Path, fileSystemProvider.RelativePath.Path, _path.Path);
        if (!string.IsNullOrEmpty(pathValidationResult))
        {
            fileSystemProvider.RelativePath = new FilePath(pathValidationResult);
            return new RequestResult.SuccessRequest();
        }

        return new RequestResult.RequestError("Wrong path!");
    }
}