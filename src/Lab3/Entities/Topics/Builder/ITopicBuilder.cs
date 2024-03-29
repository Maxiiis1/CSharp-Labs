using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;

public interface ITopicBuilder
{
    ITopicBuilder SetName(string name);
    ITopicBuilder SetRecipient(IAddressee addressee);
    ITopic Build();
}