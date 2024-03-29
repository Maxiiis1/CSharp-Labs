using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;

public class PciExpressLines : IPciExpressLines
{
    public PciExpressLines(params IVideoCard[] videoCards)
    {
        ConnectedVideoCards = videoCards.ToList();
    }

    public IReadOnlyCollection<IVideoCard> ConnectedVideoCards { get; }
}