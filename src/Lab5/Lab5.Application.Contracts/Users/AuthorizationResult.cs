namespace Lab5.Application.Contracts.Users;

public abstract record AuthorizationResult
{
    private AuthorizationResult() { }

    public sealed record Success : AuthorizationResult;

    public sealed record IncorrectLoginOrPassword : AuthorizationResult;

    public sealed record EnterAnotherLogin : AuthorizationResult;
}