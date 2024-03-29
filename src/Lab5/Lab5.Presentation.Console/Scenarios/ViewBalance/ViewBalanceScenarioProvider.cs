using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.BankAccounts;

namespace Lab5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public ViewBalanceScenarioProvider(
        IBankAccountService service,
        ICurrentBankAccountService currentUser)
    {
        _service = service;
        _currentBankAccount = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccount.BankAccount is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewBalanceScenario(_service);
        return true;
    }
}