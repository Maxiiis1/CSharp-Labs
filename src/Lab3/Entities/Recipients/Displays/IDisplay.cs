using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Displays;

public interface IDisplay
{
    void DisplayMessage(string message, Color color);
}