using System;
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

public class MotherBoardWithWiFiBuilder : IMotherBoardWithWiFiBuilder
{
    private IChipSet? ConnectedChipSet { get; set; }
    private IBios? ConnectedBios { get; set; }
    private ISataPorts? ConnectedMemoryDiscs { get; set; }
    private IRamLines? ConnectedRams { get; set; }
    private IPciExpressLines? ConnectedVideoCards { get; set; }
    private ICpuSocket? ConnectedCpu { get; set; }
    private int SupportedDdrVersion { get; set; }
    private FormFactor? FormFactor { get; set; }
    private IXmpProfile? ConnectedXmp { get; set; }
    private ICpuCooler? ConnectedCpuCooler { get; set; }

    public IMotherBoardBuilder SetChipSet(IChipSet chipSet)
    {
        ConnectedChipSet = chipSet;
        return this;
    }

    public IMotherBoardBuilder SetBios(IBios bios)
    {
        ConnectedBios = bios;
        return this;
    }

    public IMotherBoardBuilder SetMemoryDisks(ISataPorts? sataPorts)
    {
        ConnectedMemoryDiscs = sataPorts;
        return this;
    }

    public IMotherBoardBuilder SetVideoCards(IPciExpressLines? videoCards)
    {
        ConnectedVideoCards = videoCards;
        return this;
    }

    public IMotherBoardBuilder SetRam(IRamLines? rams)
    {
        ConnectedRams = rams;
        return this;
    }

    public IMotherBoardBuilder SetCpu(ICpuSocket? cpu)
    {
        ConnectedCpu = cpu;
        return this;
    }

    public IMotherBoardBuilder SetDdr(int ddr)
    {
        SupportedDdrVersion = ddr;
        return this;
    }

    public IMotherBoardBuilder SetFormFactor(FormFactor formFactor)
    {
        FormFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder SetXmp(IXmpProfile xmp)
    {
        ConnectedXmp = xmp;
        return this;
    }

    public IMotherBoardBuilder SetCooler(ICpuCooler cooler)
    {
        ConnectedCpuCooler = cooler;
        return this;
    }

    public IMotherBoard Build()
    {
        return new MotherBoardWithWiFi(
            ConnectedChipSet ?? throw new ArgumentNullException(),
            ConnectedBios ?? throw new ArgumentNullException(),
            ConnectedMemoryDiscs,
            ConnectedRams,
            ConnectedVideoCards,
            ConnectedCpu,
            SupportedDdrVersion,
            FormFactor ?? throw new ArgumentNullException(),
            ConnectedXmp ?? throw new ArgumentNullException(),
            ConnectedCpuCooler ?? throw new ArgumentNullException());
    }
}