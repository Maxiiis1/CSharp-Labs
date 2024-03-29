using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShip;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class OptimalSpaceShipTests
{
    public static IEnumerable<object[]> TestData1 =>
        new List<object[]>
        {
            new object[] { new Vaklas(new Deflector1Class()), new WalkShuttle(), new Space(400, new Meteor(0)) },
        };
    public static IEnumerable<object[]> TestData2 =>
        new List<object[]>
        {
            new object[] { new Avgur(new Deflector3Class()), new Stella(new PhotonicDeflector(new Deflector1Class())), new HeavyFog(500, new AntimatterFlare(1)), new PathResults.ShipWasLost(), new PathResults.SuccessPathResult(new List<IFuel> { new ImpulseEngineFuel(1000), new JumpEngineFuel(1) }, 10) },
            new object[] { new WalkShuttle(), new Meredian(new Deflector2Class()), new NitriteFog(300, new SpaceWhale(1)), new PathResults.ShipWasDestroyed(), new PathResults.SuccessPathResult(new List<IFuel> { new ImpulseEngineFuel(1000), new JumpEngineFuel(1) }, 5) },
        };

    [Theory]
    [MemberData(nameof(TestData1))]
    public void GetOptimalShip_ShouldReturnWalkShuttle_InSimpleSpace(Vaklas vaklas, WalkShuttle walkShuttle, IArea area)
    {
        // Arrange
        var path = new OptimalShiphChooser(area);

        // Act
        ISpaceShip result = path.GetOptimalShip(vaklas, walkShuttle);
        ISpaceShip expectedResult = walkShuttle;

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [MemberData(nameof(TestData2))]
    public void PathResult_ShouldReturnDestroyedShip_WhenFirstShip_And_Success_WhenSecondShip(ISpaceShip firstShip, ISpaceShip secondShip, IArea area, PathResults expectedResult1, PathResults expectedResult2)
    {
        // Arrange
        var path = new SpacePath(area);

        // Act
        PathResults result1 = path.PathResult(firstShip);
        PathResults result2 = path.PathResult(secondShip);

        // Assert
        Assert.Equal(expectedResult1, result1);
        Assert.NotEqual(expectedResult2, result2);
    }
}