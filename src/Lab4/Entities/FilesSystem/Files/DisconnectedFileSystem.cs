using Itmo.ObjectOrientedProgramming.Lab4.Models.FilesPath;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.RequestResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

public class DisconnectedFileSystem : IFileSystem
{
    public RequestResult Copy(FilePath sourcePath, FilePath destinationPath)
    {
        return new RequestResult.RequestError("File system was disconnected");
    }

    public RequestResult Move(FilePath sourcePath, FilePath destinationPath)
    {
        return new RequestResult.RequestError("File system was disconnected");
    }

    public RequestResult RenameFile(FilePath path, string name)
    {
        return new RequestResult.RequestError("File system was disconnected");
    }

    public RequestResult TreeList(FilePath path, int depth)
    {
        return new RequestResult.RequestError("File system was disconnected");
    }

    public RequestResult Delete(FilePath path)
    {
        return new RequestResult.RequestError("File system was disconnected");
    }

    public RequestResult Show(FilePath path, IShowStrategy strategy)
    {
        return new RequestResult.RequestError("File system was disconnected");
    }
}