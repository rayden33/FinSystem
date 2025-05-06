using FinSystem.Entities;
using FinSystem.Moqs;

namespace FinSystem.Repository;

public class UserRepository
{
    private readonly ILogger<UserRepository> _logger;
    
    public UserRepository(ILogger<UserRepository> logger)
    {
        _logger = logger;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        ArgumentException.ThrowIfNullOrEmpty(username);

        return await UserMoq.GetUserAsync(username);
    }

    public async Task AddUserAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        await UserMoq.AddUserAsync(user.Username, user.PasswordHash, user.Role);
    }
}