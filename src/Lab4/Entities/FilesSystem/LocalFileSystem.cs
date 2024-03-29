using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ConnectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem;

public class LocalFileSystem : IFileSystem
{
    public RequestResult Copy(FilePath sourcePath, FilePath destinationPath)
    {
        System.IO.File.Copy(sourcePath.Path, Path.Combine(destinationPath.Path, Path.GetFileName(sourcePath.Path)));
        return new RequestResult.SuccessRequest();
    }

    public RequestResult Move(FilePath sourcePath, FilePath destinationPath)
    {
            System.IO.File.Move(sourcePath.Path, Path.Combine(destinationPath.Path, Path.GetFileName(sourcePath.Path)));
            return new RequestResult.SuccessRequest();
    }

    public RequestResult RenameFile(FilePath path, string name)
    {
        System.IO.File.Move(path.Path, Path.Combine(Path.GetDirectoryName(path.Path) ?? string.Empty, name));
        return new RequestResult.SuccessRequest();
    }

    public RequestResult TreeList(FilePath path, int depth)
    {
        return new RequestResult.SuccessTreeRequest(new LocalDirectoryBuilding(depth).Execute(path.Path));
    }

    public RequestResult Delete(FilePath path)
    {
        System.IO.File.Delete(path.Path);
        return new RequestResult.SuccessRequest();
    }

    public RequestResult Show(FilePath path, IShowStrategy strategy)
    {
        strategy.Execute(System.IO.File.ReadAllText(path.Path));
        return new RequestResult.SuccessRequest();
    }
}