using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentAttributes.VideoCardAttributes;

public interface IPciExpressLines
{
    IReadOnlyCollection<IVideoCard> ConnectedVideoCards { get; }
}