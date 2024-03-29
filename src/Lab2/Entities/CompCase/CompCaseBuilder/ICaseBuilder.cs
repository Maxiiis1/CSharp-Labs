using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;

public interface ICaseBuilder
{
    ICaseBuilder SetMaxVideoCardLength(int length);
    ICaseBuilder SetMaxVideoCardWidth(int width);
    ICaseBuilder SetSupportedMotherBoardFormFactors(FormFactor formFactors);
    ICaseBuilder SetSize(int size);
    IComputerCase Build();
}