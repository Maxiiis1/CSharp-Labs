using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<AuthorizationResult> Login(string username, string password)
    {
        Task<User?> user = _repository.FindUserByUsername(username, password);

        if (await user is null)
        {
            return new AuthorizationResult.IncorrectLoginOrPassword();
        }

        _currentUserManager.User = await user;
        return new AuthorizationResult.Success();
    }

    public async Task<AuthorizationResult> SignUp(string username, string password, UserRole userRole)
    {
        return await _repository.AddAccountToSystem(username, password, userRole);
    }
}