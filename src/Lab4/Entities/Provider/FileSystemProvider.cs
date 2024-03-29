using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.PathValidation;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;

public class FileSystemProvider : IFileSystemProvider
{
    public FileSystemProvider(IReadOnlyDictionary<string, IFileSystem> supportedFileSystems, IReadOnlyDictionary<string, IShowStrategy> supportedShowStrategies, IPathValidator validator)
    {
        SupportedFileSystems = supportedFileSystems;
        SupportedShowStrategies = supportedShowStrategies;
        CurrentFileSystem = new LocalFileSystem();
        AbsolutePath = new FilePath(string.Empty);
        RelativePath = new FilePath(string.Empty);
        PathValidator = validator;
    }

    public FilePath RelativePath { get; set; }
    public FilePath AbsolutePath { get; set; }
    public IFileSystem CurrentFileSystem { get; private set; }
    public IPathValidator PathValidator { get; }
    public IReadOnlyDictionary<string, IShowStrategy> SupportedShowStrategies { get; }
    public IReadOnlyDictionary<string, IFileSystem> SupportedFileSystems { get; }
    public void ChangeFileSystem(IFileSystem fileSystem)
    {
        CurrentFileSystem = fileSystem;
    }
}