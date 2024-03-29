using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Models.MoneyCount;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public WithdrawMoneyScenario(IBankAccountService bankService)
    {
        _bankAccountService = bankService;
    }

    public string Name => "Withdraw money";

    public void Run()
    {
        decimal money = AnsiConsole.Ask<decimal>("Enter how much money to withdraw");

        BankOperationResult result = _bankAccountService.WithdrawMoney(new Money(money)).Result;

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