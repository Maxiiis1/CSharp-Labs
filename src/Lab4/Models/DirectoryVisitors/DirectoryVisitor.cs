using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoriesSymbols;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;
using File = Itmo.ObjectOrientedProgramming.Lab4.Entities.FilesSystem.Files.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.DirectoryVisitors;

public class DirectoryVisitor : IDirectoryVisitor
{
    private readonly string _fileSymbol;
    private readonly string _directorySymbol;
    private readonly IShowStrategy _showStrategy;
    private int _currentDepth;

    public DirectoryVisitor(IShowStrategy showStrategy, DirectorySymbols symbols)
    {
        _showStrategy = showStrategy;
        _fileSymbol = symbols.FileSymbol;
        _directorySymbol = symbols.DirectorySymbol;
    }

    public void VisitFile(File file)
    {
        _showStrategy.Execute($"{new string('\t', _currentDepth)}{_fileSymbol}{Path.GetFileName(file.Path)}");
    }

    public void VisitDirectory(FileDirectory directory)
    {
        _showStrategy.Execute($"{new string('\t', _currentDepth)}{_directorySymbol}{Path.GetFileName(directory.Path)}");
        _currentDepth++;
        foreach (IPathContent file in directory.Files)
        {
            file.Accept(this);
        }

        _currentDepth--;
    }
}