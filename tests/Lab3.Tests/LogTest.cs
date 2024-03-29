using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.Decorator;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class LogTest
{
    [Fact]
    public void Message_ShouldWriteLog()
    {
        // Arrange
        ILogger logger = Substitute.For<ILogger>();
        IMessenger messenger = new Messenger();
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new HighMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new AddresseeLoggingService(new MessengerAddressee(messenger), logger))
            .Build();

        // Act
        topic.Send(message);

        // Assert
        logger.Received().LogMessage(Arg.Any<IMessage>());
    }
}