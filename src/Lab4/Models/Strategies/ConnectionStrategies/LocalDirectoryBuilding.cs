using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ConnectionStrategies;

public class LocalDirectoryBuilding : IDirectoryBuildingStrategy
{
    private readonly int _depth;
    private int _currentDepth;

    public LocalDirectoryBuilding(int depth)
    {
        _depth = depth;
    }

    public FileDirectory Execute(string path)
    {
        var directory = new FileDirectory(System.IO.Path.GetFileName(path));

        foreach (string file in System.IO.Directory.GetFiles(path))
        {
            _currentDepth--;
            if (_currentDepth <= _depth)
            {
                directory.AddComponent(new File(System.IO.Path.GetFileName(file)));
            }

            _currentDepth++;
        }

        foreach (string subDirectory in System.IO.Directory.GetDirectories(path))
        {
            directory.AddComponent(Execute(subDirectory));
        }

        return directory;
    }
}