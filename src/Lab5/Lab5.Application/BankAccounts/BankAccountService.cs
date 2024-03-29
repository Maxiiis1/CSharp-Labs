using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.MoneyCount;
using Lab5.Application.Users;

namespace Lab5.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IOperationHistoryRepository _historyRepository;
    private readonly CurrentBankAccountManager _currentBankAccountManager;
    private readonly CurrentUserManager _currentUserManager;

    public BankAccountService(
        CurrentBankAccountManager currentAccountManager,
        IBankAccountRepository bankRepository,
        IOperationHistoryRepository historyRepository,
        CurrentUserManager currentUserManager)
    {
        _currentBankAccountManager = currentAccountManager;
        _bankAccountRepository = bankRepository;
        _historyRepository = historyRepository;
        _currentUserManager = currentUserManager;
    }

    public async Task<BankOperationResult> EnterBankAccount(int number, int pin)
    {
        Task<BankAccount?> account = _bankAccountRepository.EnterAccount(number, pin);

        if (await account is null)
        {
            return new BankOperationResult.OperationError("Wrong account number or pin!");
        }

        _currentBankAccountManager.BankAccount = await account;
        return new BankOperationResult.Success();
    }

    public async Task<BankOperationResult> CreateBankAccount(int number, int pin)
    {
        if (_currentUserManager.User != null)
        {
            long bankId = await _bankAccountRepository.CreateBankAccount(_currentUserManager.User.UserId, number, pin);
            return await _historyRepository.AddOperationToHistory("0", bankId);
        }

        return new BankOperationResult.OperationError("Enter user account!");
    }

    public async Task<BankOperationResult> AddMoney(Money money)
    {
        if (_currentBankAccountManager.BankAccount != null)
        {
            await Task.Run(async () =>
            {
                _currentBankAccountManager.BankAccount = _currentBankAccountManager.BankAccount
                    with { Money = new Money(_currentBankAccountManager.BankAccount.Money.MoneyCount + money.MoneyCount) };
                await _historyRepository.AddOperationToHistory(
                    $"+ {money.MoneyCount}",
                    _currentBankAccountManager.BankAccount.BankAccountId);
            });
            await _bankAccountRepository.AddMoney(_currentBankAccountManager.BankAccount.BankAccountId, money);
            return new BankOperationResult.Success();
        }

        return new BankOperationResult.OperationError("Enter bank account!");
    }

    public async Task<BankOperationResult> WithdrawMoney(Money money)
    {
        if (_currentBankAccountManager.BankAccount != null)
        {
            if (_currentBankAccountManager.BankAccount.Money.MoneyCount <= 0)
            {
                return new BankOperationResult.OperationError("Not enough money!");
            }

            _currentBankAccountManager.BankAccount = _currentBankAccountManager.BankAccount
                with { Money = new Money(_currentBankAccountManager.BankAccount.Money.MoneyCount - money.MoneyCount) };
            await Task.Run(async () =>
            {
                await _historyRepository.AddOperationToHistory(
                    $"- {money.MoneyCount}",
                    _currentBankAccountManager.BankAccount.BankAccountId);
            });
            await _bankAccountRepository.WithdrawMoney(_currentBankAccountManager.BankAccount.BankAccountId, money);
            return new BankOperationResult.Success();
        }

        return new BankOperationResult.OperationError("Enter bank account!");
    }

    public async Task<BankOperationResult> ViewBalance()
    {
        if (_currentBankAccountManager.BankAccount != null)
        {
            return new BankOperationResult.SuccessViewBalanceOperation(await _bankAccountRepository
                .ViewBalance(_currentBankAccountManager.BankAccount.BankAccountId));
        }

        return new BankOperationResult.OperationError("Enter bank account!");
    }

    public async Task<BankOperationResult> ViewOperationHistory()
    {
        if (_currentBankAccountManager.BankAccount != null)
        {
            IReadOnlyCollection<string> operationHistory = await _historyRepository.ViewOperationHistory(_currentBankAccountManager.BankAccount.BankAccountId);
            if (operationHistory.Count != 0)
            {
                return new BankOperationResult.SuccessHistoryOperation(operationHistory);
            }
        }

        return new BankOperationResult.OperationError("Enter bank account!");
    }
}