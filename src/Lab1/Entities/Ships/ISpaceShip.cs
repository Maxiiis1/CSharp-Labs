using Itmo.ObjectOrientedProgramming.Lab1.Models.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface ISpaceShip
{
    ICorpus Corpus { get; }
    IEngine Engine { get; }
}