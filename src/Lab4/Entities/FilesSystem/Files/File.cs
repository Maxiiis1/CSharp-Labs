using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoryVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

public class File : IPathContent
{
    public File(string path)
    {
        Path = path;
    }

    public string Path { get; }
    public void Accept(IDirectoryVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}