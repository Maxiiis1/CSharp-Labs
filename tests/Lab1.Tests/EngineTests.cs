using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class EngineTests
{
    public static IEnumerable<object[]> TestData1 =>
        new List<object[]>
        {
            new object[] { new WalkShuttle(), new Avgur(new Deflector3Class()), new HeavyFog(500, new AntimatterFlare(0)), new PathResults.ShipWasLost() },
            new object[] { new Stella(new Deflector1Class()), new Meredian(new Deflector2Class()), new HeavyFog(770, new AntimatterFlare(0)), new PathResults.ShipWasLost() },
        };

    public static IEnumerable<object[]> TestData2 =>
        new List<object[]>
        {
            new object[] { new WalkShuttle(), new Stella(new PhotonicDeflector(new Deflector1Class())), new HeavyFog(500, new AntimatterFlare(0)), new PathResults.ShipWasDestroyed(), new PathResults.SuccessPathResult(new List<IFuel> { new ImpulseEngineFuel(1000), new JumpEngineFuel(1) }, 10) },
            new object[] { new Stella(new Deflector1Class()), new Vaklas(new PhotonicDeflector(new Deflector1Class())), new HeavyFog(770, new AntimatterFlare(0)), new PathResults.ShipWasDestroyed(), new PathResults.SuccessPathResult(new List<IFuel> { new ImpulseEngineFuel(1000), new JumpEngineFuel(1) },  15) },
        };

    [Theory]
    [MemberData(nameof(TestData1))]
    public void PathResult_ShouldReturnBadResult_InHeavyFog(ISpaceShip firstShip, ISpaceShip secondShip, HeavyFog area, PathResults expectedResult)
    {
        // Arrange
        var path = new SpacePath(area);

        // Act
        PathResults result1 = path.PathResult(firstShip);
        PathResults result2 = path.PathResult(secondShip);

        // Assert
        Assert.Equal(expectedResult, result1);
        Assert.Equal(expectedResult, result2);
    }

    [Theory]
    [MemberData(nameof(TestData2))]
    public void PathResult_ShouldReturnSuccessResult_InHeavyFog(ISpaceShip firstShip, ISpaceShip secondShip, HeavyFog area, PathResults expectedResult1, PathResults expectedResult2)
    {
        // Arrange
        var path = new SpacePath(area);

        // Act
        PathResults result1 = path.PathResult(firstShip);
        PathResults result2 = path.PathResult(secondShip);

        // Assert
        Assert.NotEqual(expectedResult1, result1);
        Assert.NotEqual(expectedResult2, result2);
    }
}