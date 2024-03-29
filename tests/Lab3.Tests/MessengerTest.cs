using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTest
{
    [Fact]
    public void Message_ShouldWriteLog()
    {
        // Arrange
        IMessenger messenger = Substitute.For<IMessenger>();
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new HighMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new MessengerAddressee(messenger))
            .Build();

        // Act
        topic.Send(message);

        // Assert
        messenger.Received().DisplayMessage(Arg.Is<string>(receivedMessage => receivedMessage.Contains("Hello, body!")));
    }
}