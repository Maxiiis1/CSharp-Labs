using Lab5.Application.BankAccounts;
using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IBankAccountService, BankAccountService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<CurrentBankAccountManager>();
        collection.AddScoped<ICurrentBankAccountService>(
            p => p.GetRequiredService<CurrentBankAccountManager>());

        return collection;
    }
}