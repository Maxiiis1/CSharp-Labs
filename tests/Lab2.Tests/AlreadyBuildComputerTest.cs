using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer.PCBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class AlreadyBuildComputerTest
{
    public static IEnumerable<object[]> TestData1 =>
        new List<object[]>
        {
            new object[] { new GamingComputerBuilderDirector().Direct(new ComputerBuilder()) },
            new object[] { new OfficeComputerBuilderDirector().Direct(new ComputerBuilder()) },
        };

    [Theory]
    [MemberData(nameof(TestData1))]
    public void BuildState_ShouldReturnSuccess_WhenComputerFromRepository(IComputerBuilder computerBuilder)
    {
        Assert.True(computerBuilder.Build() is BuildResult.SuccessBuild);
    }
}