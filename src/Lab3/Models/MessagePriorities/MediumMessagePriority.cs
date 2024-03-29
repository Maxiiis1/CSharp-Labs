namespace Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

public class MediumMessagePriority : IMessagePriority
{
    public bool IsValidForRecipient(IMessagePriority recipientPriority)
    {
        return recipientPriority is MediumMessagePriority;
    }
}