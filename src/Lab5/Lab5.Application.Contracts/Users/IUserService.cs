using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    Task<AuthorizationResult> Login(string username, string password);
    Task<AuthorizationResult> SignUp(string username, string password, UserRole userRole);
}