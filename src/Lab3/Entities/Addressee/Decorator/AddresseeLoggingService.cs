using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.Decorator;

public class AddresseeLoggingService : IAddressee
{
    private readonly IAddressee _messageRecipient;
    private readonly ILogger _logger;

    public AddresseeLoggingService(IAddressee messageRecipient, ILogger logger)
    {
        _messageRecipient = messageRecipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.LogMessage(message);
        _messageRecipient.ReceiveMessage(message);
    }
}