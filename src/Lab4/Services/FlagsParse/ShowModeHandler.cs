using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.FlagsParse;

public class ShowModeHandler : FlagHandlerBase
{
    public override IReadOnlyDictionary<string, string> Handle(string[] args)
    {
        var flags = new Dictionary<string, string>();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-m")
            {
                flags["showMode"] = args[i + 1];
            }
        }

        if (NextFlagHandler != null)
        {
            foreach (KeyValuePair<string, string> pair in NextFlagHandler.Handle(args))
            {
                flags[pair.Key] = pair.Value;
            }
        }

        return flags;
    }
}