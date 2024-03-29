using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface ISpaceShipWithJumpEngine : ISpaceShip
{
    IJumpEngine JumpEngine { get; }
}