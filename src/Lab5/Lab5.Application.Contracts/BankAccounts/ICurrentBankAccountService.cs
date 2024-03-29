using Lab5.Application.Models.BankAccounts;

namespace Lab5.Application.Contracts.BankAccounts;

public interface ICurrentBankAccountService
{
    BankAccount? BankAccount { get; }
}