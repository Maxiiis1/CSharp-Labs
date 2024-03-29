using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public class VideoCardRepository : IRepository<IVideoCard>
{
    private readonly Dictionary<string, IVideoCard> _components;

    public VideoCardRepository()
    {
        IVideoCardBuilderDirector builderDirector1 = new AmdVideoCardBuilderDirector();
        IVideoCardBuilderDirector builderDirector2 = new GeforceVideoCardBuilderDirector();

        IVideoCardBuilder builder1 = builderDirector1.Direct(new VideoCardBuilder());
        IVideoCardBuilder builder2 = builderDirector2.Direct(new VideoCardBuilder());

        _components = new Dictionary<string, IVideoCard>
        {
            { "AmdVideoCard", builder1.Build() },
            { "GeforceVideoCard", builder2.Build() },
        };
    }

    public IVideoCard GetComponents(string name)
    {
        return _components[name];
    }

    public void AddComponent(string name, IVideoCard item)
    {
        _components[name] = item;
    }
}