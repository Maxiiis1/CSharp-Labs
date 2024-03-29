using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
   Task<User?> FindUserByUsername(string username, string password);
   Task<AuthorizationResult> AddAccountToSystem(string username, string password, UserRole userRole);
}