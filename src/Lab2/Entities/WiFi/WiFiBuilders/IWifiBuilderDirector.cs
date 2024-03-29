namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

public interface IWifiBuilderDirector
{
    IWiFiBuilder Direct(IWiFiBuilder wiFiBuilder);
}