using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;

public class MessageBuilder : IMessageBuilder
{
    private string? Title { get; set; }
    private string? Body { get; set; }
    private IMessagePriority? Priority { get; set; }

    public IMessageBuilder SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public IMessageBuilder SetBody(string body)
    {
        Body = body;
        return this;
    }

    public IMessageBuilder SetPriority(IMessagePriority priority)
    {
        Priority = priority;
        return this;
    }

    public IMessage Build()
    {
        return new Message(
            Title ?? throw new ArgumentNullException(),
            Body ?? throw new ArgumentNullException(),
            Priority ?? throw new ArgumentNullException());
    }
}