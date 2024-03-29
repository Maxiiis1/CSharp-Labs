namespace Itmo.ObjectOrientedProgramming.Lab3.Services.MessageStates;

public abstract record MessageState
{
    private MessageState() { }
    public sealed record Readen : MessageState;
    public sealed record UnReaden : MessageState;
    public sealed record MessageIsAlreadyReaden : MessageState;
}