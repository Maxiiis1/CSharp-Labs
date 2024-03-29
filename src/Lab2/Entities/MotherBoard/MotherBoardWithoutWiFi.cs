using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.SataPort;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoardWithoutWiFi : IMotherBoardWithoutWiFi
{
    public MotherBoardWithoutWiFi(
        IChipSet chipSet,
        IBios bios,
        ISataPorts? memoryDiscs,
        IRamLines? rams,
        IPciExpressLines? videoCards,
        ICpuSocket? cpu,
        int ddr,
        FormFactor formFactor,
        IXmpProfile xmp,
        ICpuCooler cooler,
        IWiFiAdapter? wiFiAdapter)
    {
        ConnectedChipSet = chipSet;
        ConnectedBios = bios;
        ConnectedMemoryDiscs = memoryDiscs;
        ConnectedRams = rams;
        ConnectedVideoCards = videoCards;
        ConnectedCpu = cpu;
        SupportedDdrVersion = ddr;
        FormFactor = formFactor;
        ConnectedXmp = xmp;
        ConnectedCpuCooler = cooler;
        ConnectedWiFiAdapter = wiFiAdapter;
    }

    public IChipSet ConnectedChipSet { get; }
    public IBios ConnectedBios { get; }
    public ISataPorts? ConnectedMemoryDiscs { get; }
    public IRamLines? ConnectedRams { get; }
    public IPciExpressLines? ConnectedVideoCards { get; }
    public ICpuSocket? ConnectedCpu { get; }
    public int SupportedDdrVersion { get; }
    public FormFactor FormFactor { get; }
    public IXmpProfile ConnectedXmp { get; }
    public ICpuCooler ConnectedCpuCooler { get; }
    public IWiFiAdapter? ConnectedWiFiAdapter { get; }
    public IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder)
    {
        motherBoardBuilder
            .SetFormFactor(FormFactor)
            .SetBios(ConnectedBios)
            .SetCpu(ConnectedCpu)
            .SetCooler(ConnectedCpuCooler)
            .SetMemoryDisks(ConnectedMemoryDiscs)
            .SetDdr(SupportedDdrVersion)
            .SetChipSet(ConnectedChipSet)
            .SetRam(ConnectedRams)
            .SetVideoCards(ConnectedVideoCards)
            .SetXmp(ConnectedXmp);
        return motherBoardBuilder;
    }

    public BuildResult BuildState()
    {
        if (ConnectedVideoCards == null && !ConnectedCpu.ConnectedCpu.IntegratedVideoCore)
        {
             return new BuildResult.ComponentsLack("Add video card");
        }

        if (ConnectedCpu == null)
        {
            return new BuildResult.ComponentsLack("Add CPU");
        }

        if (ConnectedRams == null)
        {
            return new BuildResult.ComponentsLack("Add random access memory");
        }

        if (ConnectedMemoryDiscs == null)
        {
            return new BuildResult.ComponentsLack("Add memory disk");
        }

        if (ConnectedChipSet.SupportedMemoryFrequancies > ConnectedCpu.ConnectedCpu.SupportedMemoryFrequencies)
        {
            return new BuildResult.ComponentsIncompatibility("Incompatibility of Cpu and Chipset");
        }

        if (ConnectedXmp != null && !ConnectedChipSet.SupportedXmp)
        {
            return new BuildResult.ComponentsIncompatibility("Incompatibility of XMP and Chipset");
        }

        if (ConnectedBios.SupportedCpu != ConnectedCpu.ConnectedCpu.Model)
        {
            return new BuildResult.ComponentsIncompatibility("Incompatibility of CPU and Bios");
        }

        if (ConnectedCpuCooler.SupportedSockets != null && !ConnectedCpuCooler.SupportedSockets.Contains(ConnectedCpu.ConnectedCpu.Model))
        {
            return new BuildResult.ComponentsIncompatibility("Incompatibility of CPU and Cooler");
        }

        if (SupportedDdrVersion > ConnectedRams.ConnectedRams.ElementAt(0).DdrVersion)
        {
            return new BuildResult.ComponentsIncompatibility("Incompatibility of random access memory and motherboard");
        }

        if (ConnectedXmp != null && ConnectedXmp.SupportedVoltage != ConnectedRams.ConnectedRams.ElementAt(0).SupportedJedec.Voltage)
        {
            return new BuildResult.ComponentsIncompatibility("Incompatibility of random access memory and xmp");
        }

        if (ConnectedCpuCooler.MaxTdp < ConnectedCpu.ConnectedCpu.Tdp)
        {
            return new BuildResult.ResponsibilityRejection("Lack of heat dissipation capacity of the cooler");
        }

        return new BuildResult.Success();
    }
}