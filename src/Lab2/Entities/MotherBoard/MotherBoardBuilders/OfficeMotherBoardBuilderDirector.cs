using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.SataPort;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;

public class OfficeMotherBoardBuilderDirector : IMotherBoardBuilderDirector
{
    public IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder)
    {
        IRepository<ICpu> cpuRepository = new CpuRepository();
        IRepository<ICpuCooler> coolerRepository = new CpuCoolerRepository();
        IRepository<IVideoCard> videoCardRepository = new VideoCardRepository();
        IRepository<IRam> ramRepository = new RamRepository();

        motherBoardBuilder
            .SetFormFactor(new FormFactor(25, 25))
            .SetBios(new Bios("Ryzen", 1, "Ryzen"))
            .SetCpu(new RyzenSocket(cpuRepository.GetComponents("RyzenCpu")))
            .SetCooler(coolerRepository.GetComponents("OfficeCooler"))
            .SetMemoryDisks(new SataPorts(new IHdd[] { new Hdd(3000, 7000, 30) }, System.Array.Empty<ISsd>()))
            .SetDdr(3)
            .SetChipSet(new SimpleChipSet())
            .SetRam(new RamLines(ramRepository.GetComponents("LargeRam")))
            .SetVideoCards(new PciExpressLines(videoCardRepository.GetComponents("AmdVideoCard")))
            .SetXmp(new Xmp(new List<int> { 12, 12, 13, 14 }, 1.35, 3000));
        return motherBoardBuilder;
    }
}