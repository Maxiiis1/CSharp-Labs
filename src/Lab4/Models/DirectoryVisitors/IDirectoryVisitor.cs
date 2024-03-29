using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoryVisitors;

public interface IDirectoryVisitor
{
    void VisitFile(File file);
    void VisitDirectory(FileDirectory directory);
}