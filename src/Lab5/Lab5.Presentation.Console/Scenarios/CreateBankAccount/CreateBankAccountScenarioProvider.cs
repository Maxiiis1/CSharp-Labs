using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.CreateBankAccount;

public class CreateBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;
    private readonly ICurrentUserService _currentUser;

    public CreateBankAccountScenarioProvider(
        IBankAccountService service,
        ICurrentBankAccountService currentAccount,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentBankAccount = currentAccount;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccount.BankAccount is not null || _currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateBankAccountScenario(_service);
        return true;
    }
}