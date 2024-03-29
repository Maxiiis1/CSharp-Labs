using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastrucure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'user'
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            user_role user_role not null ,
            password text not null
        );
        
        create table account_history
        (
            account_history_id bigint primary key generated always as identity ,
            operation_history text not null ,
            bank_account_id bigint not null references bank_accounts(bank_account_id)
        );

        create table bank_accounts
        (
            bank_account_id bigint primary key generated always as identity ,
            money_count decimal not null ,
            number int not null ,
            pin int not null ,
            user_id bigint not null references users(user_id) ,
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table account_history;
        drop table bank_accounts;

        drop type user_role;
        """;
}