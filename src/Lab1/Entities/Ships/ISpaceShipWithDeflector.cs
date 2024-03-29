using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface ISpaceShipWithDeflector : ISpaceShip
{
    IDeflector Deflector { get; }
}