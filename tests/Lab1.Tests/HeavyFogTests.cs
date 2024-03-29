using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Services.PathResult;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class HeavyFogTests
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new Vaklas(new Deflector1Class()), new Space(300, new Asteroid(1), new Meteor(1)), new HeavyFog(200, new AntimatterFlare(1)), new PathResults.PassengersWereDied() },
            new object[] { new Avgur(new Deflector3Class()), new Space(300, new Asteroid(1), new Meteor(1)), new HeavyFog(200, new AntimatterFlare(2)), new PathResults.PassengersWereDied() },
            new object[] { new WalkShuttle(), new Space(300, new Asteroid(1), new Meteor(0)), new HeavyFog(200, new AntimatterFlare(3)), new PathResults.ShipWasDestroyed() },
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void PathResult_ShouldReturnDiedPassengers_WhenFirstShip(ISpaceShip firstShip, Space firstArea, HeavyFog secondArea, PathResults expectedResult1)
    {
        // Arrange
        var path = new SpacePath(firstArea, secondArea);

        // Act
        PathResults result1 = path.PathResult(firstShip);

        // Assert
        Assert.Equal(expectedResult1, result1);
    }
}