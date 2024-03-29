namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

public class ImpulseEngineFuel : IFuel
{
    public ImpulseEngineFuel(int fuel)
    {
        if (fuel < 0)
        {
            throw new System.ArgumentException(
                "Fuel amount can`t be less zero");
        }

        Fuel = fuel;
    }

    public int Fuel { get; }
    public IFuel Summ(int right)
    {
        int result = Fuel + right;
        return new ImpulseEngineFuel(result);
    }
}