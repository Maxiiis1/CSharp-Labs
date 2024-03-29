using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Models.BankAccounts;

namespace Lab5.Application.BankAccounts;

public class CurrentBankAccountManager : ICurrentBankAccountService
{
    public BankAccount? BankAccount { get; set; }
}