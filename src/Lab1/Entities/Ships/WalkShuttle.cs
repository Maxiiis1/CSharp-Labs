using Itmo.ObjectOrientedProgramming.Lab1.Models.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
public class WalkShuttle : ISpaceShip
{
    public ICorpus Corpus { get; } = new Corpus1Class();
    public IEngine Engine { get; } = new PulseEngineC();
}