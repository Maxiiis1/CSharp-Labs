using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;

public interface IMessageBuilder
{
    IMessageBuilder SetTitle(string title);
    IMessageBuilder SetBody(string body);
    IMessageBuilder SetPriority(IMessagePriority priority);
    IMessage Build();
}