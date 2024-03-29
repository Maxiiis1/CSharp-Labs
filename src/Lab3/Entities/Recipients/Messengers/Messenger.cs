using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Messengers;

public class Messenger : IMessenger
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine("Messenger: {message}");
    }
}