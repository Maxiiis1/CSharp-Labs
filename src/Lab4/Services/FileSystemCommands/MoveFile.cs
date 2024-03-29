using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class MoveFile : IFileSystemCommand
{
    private readonly FilePath _sourcePath;
    private readonly FilePath _destinationPath;

    public MoveFile(FilePath sourcePath, FilePath destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public string SourcePath => _sourcePath.Path;
    public string DestinationPath => _destinationPath.Path;

    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        string sourcePathValidationResult = fileSystemProvider.PathValidator.Validate(fileSystemProvider.AbsolutePath.Path, fileSystemProvider.RelativePath.Path, _sourcePath.Path);
        string destinationPathValidationResult = fileSystemProvider.PathValidator.Validate(fileSystemProvider.AbsolutePath.Path, fileSystemProvider.RelativePath.Path, _destinationPath.Path);

        if (!string.IsNullOrEmpty(sourcePathValidationResult) && !string.IsNullOrEmpty(destinationPathValidationResult))
        {
            return fileSystemProvider.CurrentFileSystem.Move(new FilePath(sourcePathValidationResult), new FilePath(destinationPathValidationResult));
        }

        return new RequestResult.RequestError("Wrong path!");
    }
}