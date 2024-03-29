namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public interface IFuel
{
    int Fuel { get; }
    public IFuel Summ(int right);
}