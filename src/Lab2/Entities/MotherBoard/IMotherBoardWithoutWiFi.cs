using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoardWithoutWiFi : IMotherBoard
{
    IWiFiAdapter? ConnectedWiFiAdapter { get; }
}