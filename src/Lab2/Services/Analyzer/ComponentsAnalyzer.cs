using Itmo.ObjectOrientedProgramming.Lab2.Entities.CompCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Analyzer;

public class ComponentsAnalyzer
{
    private readonly IMotherBoard? _motherBoard;
    private readonly IComputerCase? _computerCase;
    public ComponentsAnalyzer(IMotherBoard? motherBoard, IComputerCase? computerCase)
    {
        _computerCase = computerCase;
        _motherBoard = motherBoard;
    }

    public bool AnalyseFormFactorsSuitability()
    {
        foreach (IVideoCard videoCard in _motherBoard.ConnectedVideoCards.ConnectedVideoCards)
        {
            if (_computerCase.MaxVideoCardLenght < videoCard.FormFactor.Length ||
                _computerCase.MaxVideoCardWidth < videoCard.FormFactor.Width)
            {
                return false;
            }
        }

        return true;
    }

    public int AnalysePowerConsumption()
    {
        int powerConsumption = _motherBoard.ConnectedCpu.ConnectedCpu.PowerConsumption;
        foreach (IRam ram in _motherBoard.ConnectedRams.ConnectedRams)
        {
            powerConsumption += ram.PowerConsumption;
        }

        if (_motherBoard.ConnectedVideoCards != null)
        {
            foreach (IVideoCard videocard in _motherBoard.ConnectedVideoCards.ConnectedVideoCards)
            {
                powerConsumption += videocard.PowerConcumption;
            }
        }

        foreach (IHdd hdd in _motherBoard.ConnectedMemoryDiscs.ConnectedHdd)
        {
            powerConsumption += hdd.PowerConsumption;
        }

        foreach (ISsd ssd in _motherBoard.ConnectedMemoryDiscs.ConnectedSSd)
        {
            powerConsumption += ssd.PowerConsumption;
        }

        return powerConsumption;
    }
}