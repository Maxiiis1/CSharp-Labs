using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CpuCooler;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard.MotherBoardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.CpuAttributes.CpuSocket;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.RamAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.SataPort;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentsValues;
using Itmo.ObjectOrientedProgramming.Lab2.Services.BuildResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public interface IMotherBoard : IMotherBoardBuilderDirector
{
    IChipSet ConnectedChipSet { get; }
    IBios ConnectedBios { get; }
    ISataPorts? ConnectedMemoryDiscs { get; }
    IRamLines? ConnectedRams { get; }
    IPciExpressLines? ConnectedVideoCards { get; }
    ICpuSocket? ConnectedCpu { get; }
    int SupportedDdrVersion { get; }
    FormFactor FormFactor { get; }
    IXmpProfile ConnectedXmp { get; }
    ICpuCooler ConnectedCpuCooler { get; }
    BuildResult BuildState();
}