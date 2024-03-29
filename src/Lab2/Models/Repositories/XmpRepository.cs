using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP.XMPBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class XmpRepository : IRepository<IXmpProfile>
{
    private readonly Dictionary<string, IXmpProfile> _components;

    public XmpRepository()
    {
        IXmpBuilderDirector builderDirector1 = new GamingXmpBuilderDirector();

        IXmpBuilder builder1 = builderDirector1.Direct(new XmpBuilder());

        _components = new Dictionary<string, IXmpProfile>
        {
            { "GamingXmp", builder1.Build() },
        };
    }

    public IXmpProfile GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IXmpProfile item)
    {
        _components[name] = item;
    }
}