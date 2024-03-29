using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.BankAccounts;

namespace Lab5.Presentation.Console.Scenarios.AddMoney;

public class AddMoneyScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;
    public AddMoneyScenarioProvider(
        IBankAccountService service,
        ICurrentBankAccountService currentAccountUser)
    {
        _service = service;
        _currentBankAccount = currentAccountUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccount.BankAccount is null)
        {
            scenario = null;
            return false;
        }

        scenario = new AddMoneyScenario(_service);
        return true;
    }
}