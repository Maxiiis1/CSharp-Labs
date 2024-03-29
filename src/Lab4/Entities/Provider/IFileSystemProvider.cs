using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.PathValidation;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Provider;

public interface IFileSystemProvider
{
    FilePath RelativePath { get; set; }
    FilePath AbsolutePath { get; set; }
    IFileSystem CurrentFileSystem { get; }
    IPathValidator PathValidator { get; }
    IReadOnlyDictionary<string, IShowStrategy> SupportedShowStrategies { get; }
    IReadOnlyDictionary<string, IFileSystem> SupportedFileSystems { get; }
    void ChangeFileSystem(IFileSystem fileSystem);
}