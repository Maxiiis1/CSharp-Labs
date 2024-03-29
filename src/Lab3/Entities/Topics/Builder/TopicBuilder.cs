using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;

public class TopicBuilder : ITopicBuilder
{
    private string? Name { get; set; }
    private IAddressee? MessageSender { get; set; }

    public ITopicBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public ITopicBuilder SetRecipient(IAddressee addressee)
    {
        MessageSender = addressee;
        return this;
    }

    public ITopic Build()
    {
        return new Topic(
            Name ?? throw new ArgumentNullException(),
            MessageSender ?? throw new ArgumentNullException());
    }
}