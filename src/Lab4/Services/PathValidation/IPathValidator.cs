namespace Itmo.ObjectOrientedProgramming.Lab4.Services.PathValidation;

public interface IPathValidator
{
    string Validate(string absolutePath, string relativePath, string filePath);
}