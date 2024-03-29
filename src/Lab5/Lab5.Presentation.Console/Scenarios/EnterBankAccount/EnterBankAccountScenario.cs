using Lab5.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.EnterBankAccount;

public class EnterBankAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public EnterBankAccountScenario(IBankAccountService bankService)
    {
        _bankAccountService = bankService;
    }

    public string Name => "Enter bank account";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter account number");
        int pin = AnsiConsole.Ask<int>("Enter account pin");

        BankOperationResult result = _bankAccountService.EnterBankAccount(number, pin).Result;

        string message = result switch
        {
            BankOperationResult.Success => "Success!",
            BankOperationResult.OperationError error => error.Problem,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}