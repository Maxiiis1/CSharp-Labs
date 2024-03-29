using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter password");

        AuthorizationResult result = _userService.Login(username, password).Result;

        string message = result switch
        {
            AuthorizationResult.Success => "Successful login!",
            AuthorizationResult.IncorrectLoginOrPassword => "Incorrect login or password!",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}