using Lab5.Application.Contracts.BankAccounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationHistoryRepository
{
    Task<IReadOnlyCollection<string>> ViewOperationHistory(long bankAccountId);
    Task<BankOperationResult> AddOperationToHistory(string operation, long bankAccountId);
}