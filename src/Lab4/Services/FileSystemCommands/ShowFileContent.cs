using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FileSystemCommands;

public class ShowFileContent : IFileSystemCommand
{
    private readonly FilePath _path;
    private readonly string _mode;

    public ShowFileContent(FilePath path, IReadOnlyDictionary<string, string> flags)
    {
        _mode = flags.Count != 0 ? flags["showMode"] : "console";
        _path = path;
    }

    public string Path => _path.Path;
    public string Mode => _mode;
    public RequestResult Execute(IFileSystemProvider fileSystemProvider)
    {
        fileSystemProvider.SupportedShowStrategies.TryGetValue(_mode, out IShowStrategy? strategy);
        if (strategy != null)
        {
            string pathValidationResult = fileSystemProvider.PathValidator.Validate(fileSystemProvider.AbsolutePath.Path, fileSystemProvider.RelativePath.Path, _path.Path);

            if (!string.IsNullOrEmpty(pathValidationResult))
            {
                return fileSystemProvider.CurrentFileSystem.Show(_path, strategy);
            }
        }

        return new RequestResult.RequestError("No supported show type");
    }
}