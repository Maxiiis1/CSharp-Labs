using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.MoneyCount;

namespace Lab5.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    Task<BankAccount?> EnterAccount(int number, int pin);
    Task<long> CreateBankAccount(long userId, int number, int pin);
    Task<BankOperationResult> AddMoney(long bankAccountId, Money money);
    Task<BankOperationResult> WithdrawMoney(long bankAccountId, Money money);
    Task<Money> ViewBalance(long bankAccountId);
}