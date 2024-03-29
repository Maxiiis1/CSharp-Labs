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

public class ComputerOnBaseTestSuccess
{
    public static IEnumerable<object[]> TestData1 =>
        new List<object[]>
        {
            new object[] { new PowerBlockRepository(), new ComputerCaseRepository(), new MotherBoardRepository(), new ComputerBuilder(), new ComputerBuilder() },
        };

    public static IEnumerable<object[]> TestData2 =>
        new List<object[]>
        {
            new object[] { new MotherBoardRepository(), new ComputerRepository(), new VideoCardBuilder(), new CpuBuilder() },
        };

    [Theory]
    [MemberData(nameof(TestData1))]
    public void BuildState_ShouldReturnSuccess_WhenNewComputer(PowerBlockRepository powerBlockRepository, ComputerCaseRepository caseRepository, MotherBoardRepository motherBoardRepository, IComputerBuilder builder1, IComputerBuilder builder2)
    {
        // Act
        BuildResult computer1 = builder1
            .SetCase(caseRepository.GetComponents("OfficeCase"))
            .SetMotherBoard(motherBoardRepository.GetComponents("OfficeMotherBoard"))
            .SetPowerBlock(powerBlockRepository.GetComponents("GamingPowerBlock")).Build();

        BuildResult computer2 = builder2
            .SetCase(caseRepository.GetComponents("GamingCase"))
            .SetMotherBoard(motherBoardRepository.GetComponents("GamingMotherBoard"))
            .SetPowerBlock(powerBlockRepository.GetComponents("GamingPowerBlock")).Build();

        // Assert
        Assert.True(computer1 is BuildResult.SuccessBuild);
        Assert.True(computer2 is BuildResult.SuccessBuild);
    }

    [Theory]
    [MemberData(nameof(TestData2))]
    public void BuildState_ShouldReturnSuccess_WhenNewComputerOnRepositoryBase(MotherBoardRepository motherBoardRepository, ComputerRepository computerRepository, IVideoCardBuilder videoCardBuilder, ICpuBuilder cpuBuilder)
    {
        // Arrange
        ICpu intel8 = cpuBuilder
            .SetModel("Intel")
            .SetSocket("Intel")
            .SetCoresCount(4)
            .SetCoreFrequancy(3)
            .SetMemoryFrequencies(3500)
            .SetPowerConsumption(150)
            .SetTdp(20).Build();
        IVideoCard gtx2060 = videoCardBuilder
            .SetPowerConsumption(200)
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
        Assert.True(result is BuildResult.SuccessBuild);
    }
}