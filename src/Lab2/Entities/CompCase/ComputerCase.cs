using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;

public class ComputerCase : IComputerCase
{
    public ComputerCase(int maxVideoCardLenght, int maxVideoCardWidth, FormFactor supportedMotherBoardFormFactors, int size)
    {
        MaxVideoCardLenght = maxVideoCardLenght;
        MaxVideoCardWidth = maxVideoCardWidth;
        SupportedMotherBoardFormFactors = supportedMotherBoardFormFactors;
        Size = size;
    }

    public int MaxVideoCardLenght { get; }
    public int MaxVideoCardWidth { get; }
    public FormFactor SupportedMotherBoardFormFactors { get; }
    public int Size { get; }

    public ICaseBuilder Direct(ICaseBuilder caseBuilder)
    {
        caseBuilder.SetSize(Size)
            .SetMaxVideoCardLength(MaxVideoCardLenght)
            .SetMaxVideoCardWidth(MaxVideoCardWidth)
            .SetSupportedMotherBoardFormFactors(SupportedMotherBoardFormFactors);
        return caseBuilder;
    }
}