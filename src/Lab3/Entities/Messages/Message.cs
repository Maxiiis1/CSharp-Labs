using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.MessageStates;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message : IMessage
{
    public Message(string title, string body, IMessagePriority priority)
     {
         Title = title;
         Body = body;
         Priority = priority;
         MessageState = new MessageState.UnReaden();
     }

    public string Title { get; }
    public string Body { get; }
    public IMessagePriority Priority { get; }
    public MessageState MessageState { get; }
}