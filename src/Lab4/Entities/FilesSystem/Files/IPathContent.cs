using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoryVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

public interface IPathContent
{
    string Path { get; }
    void Accept(IDirectoryVisitor visitor);
}