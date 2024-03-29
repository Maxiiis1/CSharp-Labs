using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FlagsParse;

public abstract class FlagHandlerBase
{
    protected IFlagHandler? NextFlagHandler { get; private set; }

    public IFlagHandler SetNext(IFlagHandler flagHandler)
    {
        NextFlagHandler = flagHandler;
        return flagHandler;
    }

    public abstract IReadOnlyDictionary<string, string> Handle(string[] args);
}