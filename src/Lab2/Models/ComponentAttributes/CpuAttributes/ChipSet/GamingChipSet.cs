namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;

public class GamingChipSet : IChipSet
{
    public int SupportedMemoryFrequancies { get; } = 3000;
    public bool SupportedXmp { get; } = true;
}