using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.AddresseesGroup;

public class AddresseeGroup : IAddressee
{
    private IReadOnlyCollection<IAddressee> _addressees;

    public AddresseeGroup(params IAddressee[] addressees)
    {
        _addressees = addressees.ToList();
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IAddressee addressees in _addressees)
        {
            addressees.ReceiveMessage(message);
        }
    }
}