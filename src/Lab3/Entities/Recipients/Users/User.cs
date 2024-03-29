using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Users;

public class User : IUser
{
    private readonly Dictionary<string, MessageState> _messagesStates = new();
    public IReadOnlyDictionary<string, MessageState> MessageStates => _messagesStates;

    public void ReceiveMessage(IMessage message)
    {
        _messagesStates[message.Title] = new MessageState.UnReaden();
    }

    public MessageState ReadMessage(string title)
    {
        if (_messagesStates[title] is MessageState.UnReaden)
        {
            return _messagesStates[title] = new MessageState.Readen();
        }

        return new MessageState.MessageIsAlreadyReaden();
    }
}