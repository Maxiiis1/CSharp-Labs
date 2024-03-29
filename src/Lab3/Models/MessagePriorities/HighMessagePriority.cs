namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

public class HighMessagePriority : IMessagePriority
{
    public bool IsValidForRecipient(IMessagePriority recipientPriority)
    {
        return recipientPriority is HighMessagePriority;
    }
}