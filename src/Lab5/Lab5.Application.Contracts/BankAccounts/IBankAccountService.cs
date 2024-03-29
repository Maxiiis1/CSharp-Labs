using Lab5.Application.Models.MoneyCount;

namespace Lab5.Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    Task<BankOperationResult> EnterBankAccount(int number, int pin);
    Task<BankOperationResult> CreateBankAccount(int number, int pin);
    Task<BankOperationResult> AddMoney(Money money);
    Task<BankOperationResult> WithdrawMoney(Money money);
    Task<BankOperationResult> ViewBalance();
    Task<BankOperationResult> ViewOperationHistory();
}