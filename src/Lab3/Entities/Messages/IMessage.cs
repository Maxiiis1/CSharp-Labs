using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public interface IMessage
{
    string Title { get; }
    string Body { get; }
    IMessagePriority Priority { get; }
}