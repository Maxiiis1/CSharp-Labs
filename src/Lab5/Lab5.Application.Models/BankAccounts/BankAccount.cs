using Lab5.Application.Models.MoneyCount;

namespace Lab5.Application.Models.BankAccounts;

public record BankAccount(long BankAccountId, Money Money, int Number, int Pin, long UserId);