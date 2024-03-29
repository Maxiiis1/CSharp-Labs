using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public class WiFiAdapter : IWiFiAdapter
{
    public WiFiAdapter(int wifiVersion, int pciVersion, int powerConsumption, bool hasBluetooth)
    {
        WifiVersion = wifiVersion;
        PciVersion = pciVersion;
        PowerConsumption = powerConsumption;
        HasBluetooth = hasBluetooth;
    }

    public int WifiVersion { get; }
    public int PciVersion { get; }
    public int PowerConsumption { get; }
    public bool HasBluetooth { get; }
    public IWiFiBuilder Direct(IWiFiBuilder wiFiBuilder)
    {
        wiFiBuilder.SetPciVersion(PciVersion)
            .SetPowerConsumption(PowerConsumption)
            .SetBluetooth(HasBluetooth)
            .SetWiFiVersion(WifiVersion);
        return wiFiBuilder;
    }
}