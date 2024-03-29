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

public class GamingMotherBoardBuilderDirector : IMotherBoardBuilderDirector
{
    public IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder)
    {
        IRepository<ICpu> cpuRepository = new CpuRepository();
        IRepository<ICpuCooler> coolerRepository = new CpuCoolerRepository();
        IRepository<IVideoCard> videoCardRepository = new VideoCardRepository();
        IRepository<IRam> ramRepository = new RamRepository();

        motherBoardBuilder
            .SetFormFactor(new FormFactor(30, 25))
            .SetBios(new Bios("Intel", 1, "Intel"))
            .SetCpu(new RyzenSocket(cpuRepository.GetComponents("IntelCpu")))
            .SetCooler(coolerRepository.GetComponents("GamingCooler"))
            .SetMemoryDisks(new SataPorts(new IHdd[] { new Hdd(3000, 7000, 30) }, System.Array.Empty<ISsd>()))
            .SetDdr(4)
            .SetChipSet(new GamingChipSet())
            .SetRam(new RamLines(ramRepository.GetComponents("LargeRam")))
            .SetVideoCards(new PciExpressLines(videoCardRepository.GetComponents("GeforceVideoCard")))
            .SetXmp(new Xmp(new List<int> { 12, 12, 13, 14 }, 1.35, 3000));
        return motherBoardBuilder;
    }
}