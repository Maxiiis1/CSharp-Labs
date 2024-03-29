using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShip;

public interface IOptimalShiphChooser
{
    ISpaceShip GetOptimalShip(ISpaceShip firstSpaceShip, ISpaceShip secondSpaceShip);
}