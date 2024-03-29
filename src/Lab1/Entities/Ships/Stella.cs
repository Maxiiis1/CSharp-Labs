using Itmo.ObjectOrientedProgramming.Lab1.Models.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public Stella(IDeflector deflector)
    {
        Deflector = deflector;
    }

    public IDeflector Deflector { get; }
    public ICorpus Corpus { get; } = new Corpus1Class();
    public IEngine Engine { get; } = new PulseEngineC();
    public IJumpEngine JumpEngine { get; } = new Omega();
}