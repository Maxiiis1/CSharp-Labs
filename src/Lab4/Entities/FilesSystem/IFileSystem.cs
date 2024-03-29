using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem;

public interface IFileSystem
{
    RequestResult Copy(FilePath sourcePath, FilePath destinationPath);
    RequestResult Move(FilePath sourcePath, FilePath destinationPath);
    RequestResult RenameFile(FilePath path, string name);
    RequestResult TreeList(FilePath path, int depth);
    RequestResult Delete(FilePath path);
    RequestResult Show(FilePath path, IShowStrategy strategy);
}