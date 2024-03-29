using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.SignUp;

public class SignUpScenario : IScenario
{
    private readonly IUserService _userService;

    public SignUpScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Sign up";
    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter password");
        UserRole selectedRole = AnsiConsole.Prompt(
            new SelectionPrompt<UserRole>()
                .Title("Select user role:")
                .PageSize(4)
                .AddChoices(UserRole.User, UserRole.Admin));

        AuthorizationResult result = _userService.SignUp(username, password, selectedRole).Result;

        string message = result switch
        {
            AuthorizationResult.Success => "Successful!",
            AuthorizationResult.EnterAnotherLogin => "Enter another login!",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}