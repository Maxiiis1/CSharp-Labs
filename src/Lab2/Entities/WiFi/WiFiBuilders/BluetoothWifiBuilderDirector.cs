namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

public class BluetoothWifiBuilderDirector : IWifiBuilderDirector
{
    public IWiFiBuilder Direct(IWiFiBuilder wiFiBuilder)
    {
        wiFiBuilder.SetBluetooth(true)
            .SetPowerConsumption(20)
            .SetPciVersion(2)
            .SetWiFiVersion(2);
        return wiFiBuilder;
    }
}