using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;

public class OfficeCaseBuilderDirector : ICaseBuilderDirector
{
    public ICaseBuilder Direct(ICaseBuilder caseBuilder)
    {
        caseBuilder
            .SetSize(40)
            .SetMaxVideoCardLength(25)
            .SetMaxVideoCardWidth(6)
            .SetSupportedMotherBoardFormFactors(new FormFactor(20, 20));
        return caseBuilder;
    }
}