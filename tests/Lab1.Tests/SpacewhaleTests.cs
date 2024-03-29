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

public class SpacewhaleTests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new WalkShuttle(), new Vaklas(new Deflector1Class()), new Meredian(new Deflector2Class()), new NitriteFog(200, new SpaceWhale(1)), new PathResults.ShipWasDestroyed(), new PathResults.ShipWasDestroyed(), new PathResults.SuccessPathResult(new List<IFuel> { new ImpulseEngineFuel(1000), new JumpEngineFuel(1) }, 3) },
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void PathResult_ShouldReturnDestroyedShip_WhenFirstShip_And_Success_WhenOtherShips(ISpaceShip firstShip, ISpaceShip secondShip, ISpaceShip thirdShip, NitriteFog area, PathResults firstExpectedResult, PathResults secondExpectedResult, PathResults thirdExpectedResult)
    {
        // Arrange
        var path = new SpacePath(area);

        // Act
        PathResults result1 = path.PathResult(firstShip);
        PathResults result2 = path.PathResult(secondShip);
        PathResults result3 = path.PathResult(thirdShip);

        // Assert
        Assert.Equal(firstExpectedResult, result1);
        Assert.Equal(secondExpectedResult, result2);
        Assert.NotEqual(thirdExpectedResult, result3);
    }
}