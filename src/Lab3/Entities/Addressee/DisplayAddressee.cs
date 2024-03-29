using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class DisplayAddressee : IAddressee
{
    private readonly IDisplay _addressee;
    private readonly Color _color;

    public DisplayAddressee(IDisplay addressee, Color color)
    {
        _addressee = addressee;
        _color = color;
    }

    public void ReceiveMessage(IMessage message)
    {
        _addressee.DisplayMessage(message.Body, _color);
    }
}