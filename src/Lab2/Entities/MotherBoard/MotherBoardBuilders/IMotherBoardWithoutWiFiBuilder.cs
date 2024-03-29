using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;

public interface IMotherBoardWithoutWiFiBuilder : IMotherBoardBuilder
{
    IMotherBoardBuilder SetWiFi(IWiFiAdapter? wiFiAdapter);
}