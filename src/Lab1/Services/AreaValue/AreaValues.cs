using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.AreaValue;

public class AreaValues
{
    public AreaValues(IFuel fuel, int time)
    {
        Fuel = fuel;
        Time = time;
    }

    public IFuel Fuel { get; }
    public int Time { get; }
}