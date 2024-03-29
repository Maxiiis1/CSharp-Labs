using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public interface IWiFiAdapter : IWifiBuilderDirector
{
    int WifiVersion { get; }
    int PciVersion { get; }
    int PowerConsumption { get; }
    bool HasBluetooth { get; }
}