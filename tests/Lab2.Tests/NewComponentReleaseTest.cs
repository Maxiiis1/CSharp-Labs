using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class NewComponentReleaseTest
{
    public static IEnumerable<object[]> TestData1 =>
        new List<object[]>
        {
            new object[] { new ComputerRepository(), new VideoCardRepository(), new MotherBoardRepository(), new VideoCardBuilder() },
        };

    public static IEnumerable<object[]> TestData2 =>
        new List<object[]>
        {
            new object[] { new XmpRepository(), new ComputerRepository(), new MotherBoardRepository(), new XmpBuilder(), new BuildResult.ComponentsIncompatibility("Incompatibility of random access memory and xmp") },
        };

    [Theory]
    [MemberData(nameof(TestData1))]
    public void BuildState_ShouldReturnSuccess_WhenNewVideoCardReleased(ComputerRepository computerRepository, VideoCardRepository videoCardRepository, MotherBoardRepository motherBoardRepository, IVideoCardBuilder videoCardBuilder)
    {
        IVideoCard gtx2080 = videoCardBuilder
            .SetPowerConsumption(200)
            .SetFormFactor(new FormFactor(20, 4))
            .SetPciVersion(3)
            .SetChipFrequancy(1700)
            .SetMemorySize(8)
            .Build();
        videoCardRepository.AddComponent("gtx2080", gtx2080);

        IMotherBoard newMotherBoard = motherBoardRepository.GetComponents("GamingMotherBoard")
            .Direct(new MotherBoardWithWiFiBuilder())
            .SetVideoCards(new PciExpressLines(videoCardRepository.GetComponents("gtx2080")))
            .Build();

        // Act
        BuildResult newComputer = computerRepository.GetComponents("GamingComputer")
            .Direct(new ComputerBuilder())
            .SetMotherBoard(newMotherBoard)
            .Build();

        // Assert
        Assert.True(newComputer is BuildResult.SuccessBuild);
    }

    [Theory]
    [MemberData(nameof(TestData2))]
    public void BuildState_ShouldReturnFail_WhenNewXmpReleased_And_XmpNotSupported(XmpRepository xmpRepository, ComputerRepository computerRepository, MotherBoardRepository motherBoardRepository, IXmpBuilder xmpBuilder, BuildResult expectedResult)
    {
        IXmpProfile highLevelXmp = xmpBuilder.SetFrequancy(2400).SetTimings(new int[] { 12, 12, 14, 20 }).SetVoltage(1.2).Build();
        xmpRepository.AddComponent("highLevelXmp", highLevelXmp);

        IMotherBoard newMotherBoard = motherBoardRepository.GetComponents("OfficeMotherBoard").Direct(new MotherBoardWithWiFiBuilder())
            .SetXmp(xmpRepository.GetComponents("highLevelXmp"))
            .Build();

        // Act
        BuildResult newComputer = computerRepository.GetComponents("GamingComputer").Direct(new ComputerBuilder())
            .SetMotherBoard(newMotherBoard)
            .Build();

        // Assert
        Assert.Equal(newComputer, expectedResult);
    }
}