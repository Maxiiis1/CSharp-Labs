using Lab5.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public CreateBankAccountScenario(IBankAccountService bankService)
    {
        _bankAccountService = bankService;
    }

    public string Name => "Create new bank account";
    public void Run()
    {
        int accountNumber = AnsiConsole.Ask<int>("Enter account number");
        int accountPin = AnsiConsole.Ask<int>("Enter account pin code");

        BankOperationResult result = _bankAccountService.CreateBankAccount(accountNumber, accountPin).Result;

        string message = result switch
        {
            BankOperationResult.Success => "You created new bank account!",
            BankOperationResult.OperationError error => error.Problem,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}