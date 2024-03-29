namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

public interface IMessagePriority
{
    bool IsValidForRecipient(IMessagePriority recipientPriority);
}