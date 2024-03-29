using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.PathValidation;

public class PathValidator : IPathValidator
{
    public string Validate(string absolutePath, string relativePath, string filePath)
    {
        if (System.IO.Path.Exists(Path.Combine(absolutePath, filePath)))
        {
            return Path.Combine(absolutePath, filePath);
        }

        if (System.IO.Path.Exists(Path.Combine(relativePath, filePath)))
        {
            return Path.Combine(relativePath, filePath);
        }

        return string.Empty;
    }
}