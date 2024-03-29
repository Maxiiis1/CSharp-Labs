using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _addressee;

    public MessengerAddressee(IMessenger addressee)
    {
        _addressee = addressee;
    }

    public void ReceiveMessage(IMessage message)
    {
        _addressee.DisplayMessage(message.Body);
    }
}