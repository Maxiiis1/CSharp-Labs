using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Users;

public interface IUser
{
    IReadOnlyDictionary<string, MessageState> MessageStates { get; }
    MessageState ReadMessage(string title);
    void ReceiveMessage(IMessage message);
}