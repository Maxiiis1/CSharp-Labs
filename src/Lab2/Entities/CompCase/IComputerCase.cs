using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;

public interface IComputerCase : ICaseBuilderDirector
{
    int MaxVideoCardLenght { get; }
    int MaxVideoCardWidth { get; }
    FormFactor SupportedMotherBoardFormFactors { get; }
    int Size { get; }
}