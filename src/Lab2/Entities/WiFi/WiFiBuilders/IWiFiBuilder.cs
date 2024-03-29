namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

public interface IWiFiBuilder
{
    IWiFiBuilder SetWiFiVersion(int version);
    IWiFiBuilder SetPciVersion(int version);
    IWiFiBuilder SetBluetooth(bool hasBluetooth);
    IWiFiBuilder SetPowerConsumption(int consumption);
    IWiFiAdapter Build();
}