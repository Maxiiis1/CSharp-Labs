using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi.WiFiBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class WiFiRepository : IRepository<IWiFiAdapter>
{
    private readonly Dictionary<string, IWiFiAdapter> _components;

    public WiFiRepository()
    {
        IWifiBuilderDirector builderDirector1 = new BluetoothWifiBuilderDirector();

        IWiFiBuilder builder1 = builderDirector1.Direct(new WiFiBuilder());

        _components = new Dictionary<string, IWiFiAdapter>
        {
            { "BluetoothWifi", builder1.Build() },
        };
    }

    public IWiFiAdapter GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IWiFiAdapter item)
    {
        _components[name] = item;
    }
}