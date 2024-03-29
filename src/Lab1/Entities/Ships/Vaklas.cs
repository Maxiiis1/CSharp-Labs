using Itmo.ObjectOrientedProgramming.Lab1.Models.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
public class Vaklas : ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public Vaklas(IDeflector deflector)
    {
        Deflector = deflector;
    }

    public IDeflector Deflector { get; }
    public ICorpus Corpus { get; } = new Corpus2Class();
    public IEngine Engine { get; } = new PulseEngineE();
    public IJumpEngine JumpEngine { get; } = new Gamma();
}