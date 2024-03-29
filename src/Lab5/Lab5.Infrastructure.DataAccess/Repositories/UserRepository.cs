using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastrucure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string username, string password)
    {
        const string sql = """
       select user_id, user_name, user_role
       from users
       where user_name = :username
       and password = :password;
       """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        command.AddParameter("password", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync() is false)
            return null;

        return
            new User(
                reader.GetInt64(0),
                reader.GetString(1),
                await reader.GetFieldValueAsync<UserRole>(2));
    }

    public async Task<AuthorizationResult> AddAccountToSystem(string username, string password, UserRole userRole)
    {
        const string sql = """
        select user_id, user_name, user_role
        from users
        where user_name = :username;
        """;

        const string sqlUserInsert = """
        insert into users (user_name, user_role, password)
        values (:username, :userRole, :password);
        """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using (var accountExistsCommand = new NpgsqlCommand(sql, connection))
        {
            accountExistsCommand.AddParameter("username", username);

            await using NpgsqlDataReader reader = await accountExistsCommand.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new AuthorizationResult.EnterAnotherLogin();
            }
        }

        await using var insertNewUserCommand = new NpgsqlCommand(sqlUserInsert, connection);

        insertNewUserCommand.AddParameter("username", username);
        insertNewUserCommand.AddParameter("userRole", userRole);
        if (userRole is UserRole.Admin)
        {
            insertNewUserCommand.AddParameter("password", "000");
        }

        insertNewUserCommand.AddParameter("password", password);

        await insertNewUserCommand.ExecuteNonQueryAsync();
        return new AuthorizationResult.Success();
    }
}