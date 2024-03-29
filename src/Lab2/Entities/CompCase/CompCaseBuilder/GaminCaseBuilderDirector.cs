using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;

public class GaminCaseBuilderDirector : ICaseBuilderDirector
{
    public ICaseBuilder Direct(ICaseBuilder caseBuilder)
    {
        caseBuilder
            .SetSize(80)
            .SetMaxVideoCardLength(30)
            .SetMaxVideoCardWidth(7)
            .SetSupportedMotherBoardFormFactors(new FormFactor(30, 25));
        return caseBuilder;
    }
}