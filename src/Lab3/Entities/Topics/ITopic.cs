using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public interface ITopic
{
    string Name { get; }
    IAddressee Addressee { get; }
    void Send(IMessage message);
}