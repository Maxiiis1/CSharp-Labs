using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Sender.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class PriorityTest
{
    [Fact]
    public void Message_ShouldNotBeSended_WhenNotEnoughtPriority()
    {
        // Arrange
        IUser user = Substitute.For<IUser>();
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new HighMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new AddresseeFilterProxy(new LowMessagePriority(), new UserAddressee(user)))
            .Build();

        // Act
        topic.Send(message);
        user.ReadMessage(message.Title);

        // Assert
        user.Received(0).ReceiveMessage(Arg.Any<IMessage>());
    }
}