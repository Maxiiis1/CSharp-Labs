namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;

public interface IChipSet
{
    int SupportedMemoryFrequancies { get; }
    bool SupportedXmp { get; }
}