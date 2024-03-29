using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.Proxy;

public class AddresseeFilterProxy : IAddressee
{
    private readonly IMessagePriority _userPriority;
    private readonly IAddressee _addressee;

    public AddresseeFilterProxy(IMessagePriority priority, IAddressee recipient)
    {
        _userPriority = priority;
        _addressee = recipient;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message.Priority.IsValidForRecipient(_userPriority))
        {
            _addressee.ReceiveMessage(message);
        }
    }
}