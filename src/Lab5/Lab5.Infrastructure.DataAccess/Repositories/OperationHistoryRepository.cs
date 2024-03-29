using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.BankAccounts;
using Npgsql;

namespace Lab5.Infrastrucure.DataAccess.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationHistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<IReadOnlyCollection<string>> ViewOperationHistory(long bankAccountId)
    {
        var result = new List<string>();

        const string sql = """
       select operation_history
       from account_history
       where bank_account_id = :current_account_id;
       """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("current_account_id", bankAccountId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            result.Add(reader.GetString(0));
        }

        return result;
    }

    public async Task<BankOperationResult> AddOperationToHistory(string operation, long bankAccountId)
    {
        const string sqlHistoryInsert = """
        insert into account_history (operation_history, bank_account_id)
        values (:operation, :bank_account_id)
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);
        await using var insertNewHistoryCommand = new NpgsqlCommand(sqlHistoryInsert, connection);

        insertNewHistoryCommand.AddParameter("operation", operation);
        insertNewHistoryCommand.AddParameter("bank_account_id", bankAccountId);

        await insertNewHistoryCommand.ExecuteNonQueryAsync();

        return new BankOperationResult.Success();
    }
}