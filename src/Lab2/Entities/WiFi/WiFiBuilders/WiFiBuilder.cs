namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

public class WiFiBuilder : IWiFiBuilder
{
    private int WifiVersion { get; set; } = 1;
    private int PciVersion { get; set; } = 1;
    private int PowerConsumption { get; set; } = 20;
    private bool HasBluetooth { get; set; }

    public IWiFiBuilder SetWiFiVersion(int version)
    {
        WifiVersion = version;
        return this;
    }

    public IWiFiBuilder SetPciVersion(int version)
    {
        PciVersion = version;
        return this;
    }

    public IWiFiBuilder SetBluetooth(bool hasBluetooth)
    {
        HasBluetooth = hasBluetooth;
        return this;
    }

    public IWiFiBuilder SetPowerConsumption(int consumption)
    {
        PowerConsumption = consumption;
        return this;
    }

    public IWiFiAdapter Build()
    {
        return new WiFiAdapter(WifiVersion, PciVersion, PowerConsumption, HasBluetooth);
    }
}