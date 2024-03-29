using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ConnectionStrategies;

public interface IDirectoryBuildingStrategy
{
    FileDirectory Execute(string path);
}