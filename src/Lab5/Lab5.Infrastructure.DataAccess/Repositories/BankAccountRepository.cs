using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.BankAccounts;
using Lab5.Application.Models.BankAccounts;
using Lab5.Application.Models.MoneyCount;
using Npgsql;

namespace Lab5.Infrastrucure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<BankAccount?> EnterAccount(int number, int pin)
    {
        const string sql = """
       select *
       from bank_accounts
       where number = :number
       and pin = :pin;
       """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", number);
        command.AddParameter("pin", pin);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return
            new BankAccount(
                reader.GetInt64(0),
                new Money(reader.GetDecimal(1)),
                reader.GetInt32(2),
                reader.GetInt32(3),
                reader.GetInt64(4));
    }

    public async Task<long> CreateBankAccount(long userId, int number, int pin)
    {
        const string sqlAccountInsert = """
        insert into bank_accounts (money_count, number, pin, user_id)
        values (:money, :number, :pin, :user_id)
        returning bank_account_id;
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        using var insertNewAccountCommand = new NpgsqlCommand(sqlAccountInsert, connection);
        insertNewAccountCommand.AddParameter("money", 0);
        insertNewAccountCommand.AddParameter("number", number);
        insertNewAccountCommand.AddParameter("pin", pin);
        insertNewAccountCommand.AddParameter("user_id", userId);

        await insertNewAccountCommand.ExecuteNonQueryAsync();

        return (long)(await insertNewAccountCommand.ExecuteScalarAsync() ?? 0);
    }

    public async Task<BankOperationResult> AddMoney(long bankAccountId, Money money)
    {
        const string sqlAddMoney = """
       update bank_accounts
       set money_count = money_count + :money
       where bank_account_id = :bank_account_id;
       """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var addMoneyCommand = new NpgsqlCommand(sqlAddMoney, connection);

        addMoneyCommand.AddParameter("bank_account_id", bankAccountId);
        addMoneyCommand.AddParameter("money", money.MoneyCount);

        await addMoneyCommand.ExecuteNonQueryAsync();

        return new BankOperationResult.Success();
    }

    public async Task<BankOperationResult> WithdrawMoney(long bankAccountId, Money money)
    {
        const string sqlWithdrawMoney = """
        update bank_accounts
        set money_count = money_count - :money
        where bank_account_id = :bank_account_id;
        """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var withdrawMoneyCommand = new NpgsqlCommand(sqlWithdrawMoney, connection);
        withdrawMoneyCommand.AddParameter("bank_account_id", bankAccountId);
        withdrawMoneyCommand.AddParameter("money", money.MoneyCount);

        await withdrawMoneyCommand.ExecuteNonQueryAsync();

        return new BankOperationResult.Success();
    }

    public async Task<Money> ViewBalance(long bankAccountId)
    {
        const string sql = """
       select money_count
       from bank_accounts
       where bank_account_id = :current_account_id;
       """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("current_account_id", bankAccountId);

        decimal money = (decimal)(await command.ExecuteScalarAsync() ?? 0);
        return new Money(money);
    }
}