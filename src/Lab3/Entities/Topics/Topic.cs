using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic : ITopic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; }
    public IAddressee Addressee { get; }

    public void Send(IMessage message)
    {
        Addressee.ReceiveMessage(message);
    }
}