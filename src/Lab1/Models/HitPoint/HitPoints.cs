namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HitPoint;
public class HitPoints
{
    public HitPoints(int hp)
    {
        if (hp < 0)
        {
            hp = 0;
        }

        Health = hp;
    }

    public int Health { get; }

    public static HitPoints Subtract(HitPoints left, int right)
    {
        int value = left.Health - right;
        return new HitPoints(value);
    }
}
