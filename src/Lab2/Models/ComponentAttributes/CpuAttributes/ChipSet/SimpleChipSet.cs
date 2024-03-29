namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;

public class SimpleChipSet : IChipSet
{
    public int SupportedMemoryFrequancies { get; } = 1000;
    public bool SupportedXmp { get; } = true;
}