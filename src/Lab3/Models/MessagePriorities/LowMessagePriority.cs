namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

public class LowMessagePriority : IMessagePriority
{
    public bool IsValidForRecipient(IMessagePriority recipientPriority)
    {
        return recipientPriority is LowMessagePriority;
    }
}