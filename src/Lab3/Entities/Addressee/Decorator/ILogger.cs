using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.Decorator;

public interface ILogger
{
    void LogMessage(IMessage message);
}