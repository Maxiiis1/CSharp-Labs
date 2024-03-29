using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase.CompCaseBuilder;

public class CaseBuilder : ICaseBuilder
{
    private int MaxVideoCardLenght { get; set; }
    private int MaxVideoCardWidth { get; set; }
    private FormFactor? SupportedMotherBoardFormFactors { get; set; }
    private int Size { get; set; }

    public ICaseBuilder SetMaxVideoCardLength(int length)
    {
        MaxVideoCardLenght = length;
        return this;
    }

    public ICaseBuilder SetMaxVideoCardWidth(int width)
    {
        MaxVideoCardWidth = width;
        return this;
    }

    public ICaseBuilder SetSupportedMotherBoardFormFactors(FormFactor formFactors)
    {
        SupportedMotherBoardFormFactors = formFactors;
        return this;
    }

    public ICaseBuilder SetSize(int size)
    {
        Size = size;
        return this;
    }

    public IComputerCase Build()
    {
        return new ComputerCase(
            MaxVideoCardLenght,
            MaxVideoCardWidth,
            SupportedMotherBoardFormFactors ?? throw new ArgumentNullException(),
            Size);
    }
}