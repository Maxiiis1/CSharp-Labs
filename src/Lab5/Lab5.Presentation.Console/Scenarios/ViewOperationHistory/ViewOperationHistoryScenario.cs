using Lab5.Application.Contracts.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ViewOperationHistory;

public class ViewOperationHistoryScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;

    public ViewOperationHistoryScenario(IBankAccountService bankService)
    {
        _bankAccountService = bankService;
    }

    public string Name => "View operation history";
    public void Run()
    {
        BankOperationResult result = _bankAccountService.ViewOperationHistory().Result;

        if (result is BankOperationResult.SuccessHistoryOperation historyOperation)
        {
            foreach (string operation in historyOperation.History)
            {
                AnsiConsole.WriteLine(operation);
            }
        }
        else if (result is BankOperationResult.OperationError error)
        {
            AnsiConsole.WriteLine(error.Problem);
        }

        AnsiConsole.Ask<string>("Ok");
    }
}