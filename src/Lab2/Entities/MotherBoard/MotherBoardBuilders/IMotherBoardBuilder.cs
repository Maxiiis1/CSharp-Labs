using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.SataPort;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder SetChipSet(IChipSet chipSet);
    IMotherBoardBuilder SetBios(IBios bios);
    IMotherBoardBuilder SetMemoryDisks(ISataPorts? sataPorts);
    IMotherBoardBuilder SetVideoCards(IPciExpressLines? videoCards);
    IMotherBoardBuilder SetRam(IRamLines? rams);
    IMotherBoardBuilder SetCpu(ICpuSocket? cpu);
    IMotherBoardBuilder SetDdr(int ddr);
    IMotherBoardBuilder SetFormFactor(FormFactor formFactor);
    IMotherBoardBuilder SetCooler(ICpuCooler cooler);
    IMotherBoardBuilder SetXmp(IXmpProfile xmp);
    IMotherBoard Build();
}