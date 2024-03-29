using System.Globalization;
using Lab5.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public ViewBalanceScenario(IBankAccountService bankService)
    {
        _bankAccountService = bankService;
    }

    public string Name => "View balance";
    public void Run()
    {
        BankOperationResult result = _bankAccountService.ViewBalance().Result;

        string message = result switch
        {
            BankOperationResult.SuccessViewBalanceOperation balance => balance.Money.MoneyCount.ToString(CultureInfo.InvariantCulture),
            BankOperationResult.OperationError error => error.Problem,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}