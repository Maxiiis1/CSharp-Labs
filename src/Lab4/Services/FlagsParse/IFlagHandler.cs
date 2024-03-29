using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FlagsParse;

public interface IFlagHandler
{
    IReadOnlyDictionary<string, string> Handle(string[] args);
    IFlagHandler SetNext(IFlagHandler flagHandler);
}