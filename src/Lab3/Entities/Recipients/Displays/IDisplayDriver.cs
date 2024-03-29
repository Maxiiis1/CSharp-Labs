using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Displays;

public interface IDisplayDriver
{
    void SetColor(Color color);
    void ClearOutput();
    void Display(string text);
}