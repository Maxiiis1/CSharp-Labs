using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.Decorator;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee.Decorator;

public class ConsoleLogger : ILogger
{
    public void LogMessage(IMessage message)
    {
        Console.WriteLine(message.Title);
        Console.WriteLine(message.Body);
    }
}