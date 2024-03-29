using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Program
{
    private static void Main()
    {
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new LowMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new DisplayAddressee(new Display(), Color.Brown))
            .Build();

        topic.Send(message);

        IMessage message2 = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, man!")
            .SetPriority(new LowMessagePriority()).Build();
        topic.Send(message2);
    }
}