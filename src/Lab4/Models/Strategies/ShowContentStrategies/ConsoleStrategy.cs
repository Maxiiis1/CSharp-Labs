using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Strategies.ShowFileStrategies;

public class ConsoleStrategy : IShowStrategy
{
    public void Execute(string content)
    {
        Console.WriteLine(content);
    }
}