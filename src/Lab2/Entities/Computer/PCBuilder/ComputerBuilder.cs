using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCPowerBlock;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Analyzer;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;

public class ComputerBuilder : IComputerBuilder
{
    private IComputerCase? ComputerCase { get; set; }
    private IPowerBlock? PowerBlock { get; set; }
    private IMotherBoard? MotherBoard { get; set; }
    public IComputerBuilder SetCase(IComputerCase computerCase)
    {
        ComputerCase = computerCase;
        return this;
    }

    public IComputerBuilder SetPowerBlock(IPowerBlock powerBlock)
    {
        PowerBlock = powerBlock;
        return this;
    }

    public IComputerBuilder SetMotherBoard(IMotherBoard motherBoard)
    {
        MotherBoard = motherBoard;
        return this;
    }

    public BuildResult Build()
    {
        BuildResult buildResult = BuildResult();
        if (buildResult != new BuildResult.Success())
        {
            return buildResult;
        }

        return new BuildResult.SuccessBuild(new Computer(
            ComputerCase ?? throw new ArgumentNullException(),
            PowerBlock ?? throw new ArgumentNullException(),
            MotherBoard ?? throw new ArgumentNullException()));
    }

    private BuildResult BuildResult()
    {
        var componentsAnalyzer = new ComponentsAnalyzer(MotherBoard, ComputerCase);
        if (ComputerCase == null)
        {
            return new BuildResult.ComponentsLack("Add computer case");
        }

        if (MotherBoard == null)
        {
            return new BuildResult.ComponentsLack("Add motherboard");
        }

        if (PowerBlock == null)
        {
            return new BuildResult.ComponentsLack("Add power block");
        }

        if (MotherBoard.BuildState() != new BuildResult.Success())
        {
            return MotherBoard.BuildState();
        }

        if (MotherBoard.ConnectedVideoCards != null)
        {
            if (!componentsAnalyzer.AnalyseFormFactorsSuitability())
            {
                return new BuildResult.ComponentsIncompatibility("Computer case does not fit");
            }
        }

        if (PowerBlock.MaxPowerLoad < componentsAnalyzer.AnalysePowerConsumption())
        {
            return new BuildResult.ResponsibilityRejection("Not enough power of power block");
        }

        return new BuildResult.Success();
    }
}