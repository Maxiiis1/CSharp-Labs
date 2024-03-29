using Lab5.Presentation.Console.Scenarios.AddMoney;
using Lab5.Presentation.Console.Scenarios.CreateBankAccount;
using Lab5.Presentation.Console.Scenarios.EnterBankAccount;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.SignUp;
using Lab5.Presentation.Console.Scenarios.ViewBalance;
using Lab5.Presentation.Console.Scenarios.ViewOperationHistory;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SignUpScenarioProvider>();
        collection.AddScoped<IScenarioProvider, EnterBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewOperationHistoryScenarioProvider>();

        return collection;
    }
}