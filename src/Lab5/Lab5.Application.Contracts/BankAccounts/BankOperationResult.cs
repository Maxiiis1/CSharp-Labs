using Lab5.Application.Models.MoneyCount;

namespace Lab5.Application.Contracts.BankAccounts;

public abstract record BankOperationResult
{
    private BankOperationResult() { }

    public sealed record Success : BankOperationResult;
    public sealed record OperationError(string Problem) : BankOperationResult;
    public sealed record SuccessViewBalanceOperation(Money Money) : BankOperationResult;
    public sealed record SuccessHistoryOperation(IReadOnlyCollection<string> History) : BankOperationResult;
}