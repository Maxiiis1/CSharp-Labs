using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class UserAddressee : IAddressee
{
    private readonly IUser _addressee;

    public UserAddressee(IUser addressee)
    {
        _addressee = addressee;
    }

    public void ReceiveMessage(IMessage message)
    {
        _addressee.ReceiveMessage(message);
    }
}