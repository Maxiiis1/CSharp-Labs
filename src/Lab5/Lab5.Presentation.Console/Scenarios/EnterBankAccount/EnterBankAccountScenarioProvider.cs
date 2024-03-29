using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.EnterBankAccount;

public class EnterBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;
    private readonly ICurrentUserService _currentUser;

    public EnterBankAccountScenarioProvider(
        IBankAccountService service,
        ICurrentBankAccountService currentUser,
        ICurrentUserService currentUser1)
    {
        _service = service;
        _currentBankAccount = currentUser;
        _currentUser = currentUser1;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccount.BankAccount is not null || _currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new EnterBankAccountScenario(_service);
        return true;
    }
}