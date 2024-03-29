using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.BankAccounts;
using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.MoneyCount;
using Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BalanceTests
{
    [Fact]
    public void AddMoney_ShouldReturnSuccess()
    {
        // Arrange
        IOperationHistoryRepository historyRepository = Substitute.For<IOperationHistoryRepository>();
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        var bankAcc = new CurrentBankAccountManager();
        bankAcc.BankAccount = new BankAccount(1600, new Money(20), 3434, 3434, 150);

        var bankAccountService = new BankAccountService(
            bankAcc,
            bankAccountRepository,
            historyRepository,
            new CurrentUserManager());

        // Act
        BankOperationResult result = bankAccountService.AddMoney(new Money(100)).Result;

        // Assert
        Assert.IsType<BankOperationResult.Success>(result);
        bankAccountRepository.Received(1).AddMoney(1600, Arg.Is<Money>(m => m.MoneyCount == 100));
    }

    [Fact]
    public void WuthdrawMoney_ShouldReturnSuccess_WhenEnoughMoney()
    {
        // Arrange
        IOperationHistoryRepository historyRepository = Substitute.For<IOperationHistoryRepository>();
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        var bankAcc = new CurrentBankAccountManager();
        bankAcc.BankAccount = new BankAccount(1600, new Money(20), 3434, 3434, 150);

        var bankAccountService = new BankAccountService(
            bankAcc,
            bankAccountRepository,
            historyRepository,
            new CurrentUserManager());

        // Act
        BankOperationResult result = bankAccountService.WithdrawMoney(new Money(10)).Result;

        // Assert
        Assert.IsType<BankOperationResult.Success>(result);
        bankAccountRepository.Received(1).WithdrawMoney(1600, Arg.Is<Money>(m => m.MoneyCount == 10));
    }

    [Fact]
    public void WuthdrawMoney_ShouldReturnNotEnoughMoney_WhenTooMuchMoney()
    {
        // Arrange
        IOperationHistoryRepository historyRepository = Substitute.For<IOperationHistoryRepository>();
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        var bankAcc = new CurrentBankAccountManager();
        bankAcc.BankAccount = new BankAccount(1600, new Money(20), 3434, 3434, 150);

        var bankAccountService = new BankAccountService(
            bankAcc,
            bankAccountRepository,
            historyRepository,
            new CurrentUserManager());

        // Act
        BankOperationResult result = bankAccountService.WithdrawMoney(new Money(10)).Result;

        // Assert
        if (result is BankOperationResult.OperationError problem)
        {
            Assert.True(problem.Problem == "Not enough money!");
        }

        bankAccountRepository.Received(0);
    }
}