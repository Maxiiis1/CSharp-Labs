using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver = new DisplayDriver();
    public void DisplayMessage(string message, Color color)
    {
        _displayDriver.ClearOutput();
        _displayDriver.SetColor(color);
        _displayDriver.Display(message);
    }
}