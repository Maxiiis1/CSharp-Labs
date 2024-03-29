using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoryVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

public class FileDirectory : IPathContent
{
    private readonly List<IPathContent> _files = new();
    public FileDirectory(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public IReadOnlyCollection<IPathContent> Files => _files;
    public void Accept(IDirectoryVisitor visitor)
    {
        visitor.VisitDirectory(this);
    }

    public void AddComponent(IPathContent directoryComponent)
    {
        _files.Add(directoryComponent);
    }
}