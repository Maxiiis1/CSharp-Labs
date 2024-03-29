using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipients.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessagePriorities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.MessageStates;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageStateTest
{
    [Fact]
    public void MessageState_ShouldReturnUnreaden_WhenUserDidntReadMessage()
    {
        // Arrange
        IUser user = new User();
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new LowMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new UserAddressee(user))
            .Build();

        topic.Send(message);

        // Act
        MessageState result = user.MessageStates[message.Title];

        // Assert
        Assert.True(result is MessageState.UnReaden);
    }

    [Fact]
    public void MessageState_ShouldReturnReaden_WhenUserReadMessage()
    {
        // Arrange
        IUser user = new User();
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new LowMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new UserAddressee(user))
            .Build();

        topic.Send(message);
        user.ReadMessage(message.Title);

        // Act
        MessageState result = user.MessageStates[message.Title];

        // Assert
        Assert.True(result is MessageState.Readen);
    }

    [Fact]
    public void MessageState_ShouldReturnReadenError_WhenUserReadMessageAgain()
    {
        // Arrange
        IUser user = new User();
        IMessage message = new MessageBuilder()
            .SetTitle("Hi")
            .SetBody("Hello, body!")
            .SetPriority(new LowMessagePriority()).Build();
        ITopic topic = new TopicBuilder().SetName("greeting")
            .SetRecipient(new UserAddressee(user))
            .Build();

        topic.Send(message);
        user.ReadMessage(message.Title);

        // Act
        MessageState result = user.ReadMessage(message.Title);

        // Assert
        Assert.True(result is MessageState.MessageIsAlreadyReaden);
    }
}