using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU.CPUBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerOnBaseTestResponobilityRejection
{
    public static IEnumerable<object[]> TestData1 =>
        new List<object[]>
        {
            new object[] { new MotherBoardRepository(), new ComputerRepository(), new CpuBuilder(), new BuildResult.ResponsibilityRejection("Lack of heat dissipation capacity of the cooler") },
        };
    public static IEnumerable<object[]> TestData2 =>
        new List<object[]>
        {
            new object[] { new MotherBoardRepository(), new ComputerRepository(), new VideoCardBuilder(), new CpuBuilder(), new BuildResult.ResponsibilityRejection("Not enough power of power block") },
        };

    [Theory]
    [MemberData(nameof(TestData1))]
    public void BuildState_ShouldReturnResponsobilityRejection_WhenNewComputerHasWrongCpu(MotherBoardRepository motherBoardRepository, ComputerRepository computerRepository, ICpuBuilder cpuBuilder, BuildResult expectedResult)
    {
        // Arrange
        ICpu intel8 = cpuBuilder
            .SetModel("Intel")
            .SetSocket("Intel")
            .SetCoresCount(4)
            .SetCoreFrequancy(3)
            .SetMemoryFrequencies(3500)
            .SetPowerConsumption(150)
            .SetTdp(70).Build();

        IMotherBoardBuilder newMotherBoardBuilder = motherBoardRepository
            .GetComponents("GamingMotherBoard")
            .Direct(new MotherBoardWithWiFiBuilder())
            .SetCpu(new IntelSocket(intel8));

        IComputerBuilder newComputerBuilder = computerRepository.GetComponents("GamingComputer")
            .Direct(new ComputerBuilder())
            .SetMotherBoard(newMotherBoardBuilder.Build());

        // Act
        BuildResult result = newComputerBuilder.Build();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(TestData2))]
    public void BuildState_ShouldReturnResponsobilityRejection_WhenNewComputerHasMorePower(MotherBoardRepository motherBoardRepository, ComputerRepository computerRepository, IVideoCardBuilder videoCardBuilder, ICpuBuilder cpuBuilder, BuildResult expectedResult)
    {
        // Arrange
        ICpu intel8 = cpuBuilder
            .SetModel("Intel")
            .SetSocket("Intel")
            .SetCoresCount(4)
            .SetCoreFrequancy(3)
            .SetMemoryFrequencies(3500)
            .SetPowerConsumption(400)
            .SetTdp(20).Build();
        IVideoCard gtx2060 = videoCardBuilder
            .SetPowerConsumption(400)
            .SetFormFactor(new FormFactor(20, 4))
            .SetPciVersion(3)
            .SetChipFrequancy(1600)
            .SetMemorySize(4)
            .Build();

        IMotherBoardBuilder newMotherBoardBuilder = motherBoardRepository
            .GetComponents("GamingMotherBoard")
            .Direct(new MotherBoardWithWiFiBuilder())
            .SetCpu(new IntelSocket(intel8))
            .SetVideoCards(new PciExpressLines(gtx2060));

        IComputerBuilder newComputerBuilder = computerRepository.GetComponents("GamingComputer")
            .Direct(new ComputerBuilder())
            .SetMotherBoard(newMotherBoardBuilder.Build());

        // Act
        BuildResult result = newComputerBuilder.Build();

        // Assert
        Assert.Equal(expectedResult, result);
    }
}