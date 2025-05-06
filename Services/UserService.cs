using FinSystem.Entities;
using FinSystem.Models.DTOs;
using FinSystem.Moqs;
using FinSystem.Providers;
using FinSystem.Repository;

namespace FinSystem.Services;

public class UserService
{
    private readonly ILogger<UserService> _logger;
    private readonly PasswordHasher _passwordHasher;
    private readonly UserRepository _userRepository;
    private readonly JwtProvider _jwtProvider;
    
    public UserService(ILogger<UserService> logger, PasswordHasher passwordHasher, UserRepository userRepository,  JwtProvider jwtProvider)
    {
        _logger = logger;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }
    public async Task RegisterAsync(string username, string password)
    {
        var hashedPassword = _passwordHasher.GeneratePasswordHash(password);

        await _userRepository.AddUserAsync(new User() { Username = username, PasswordHash = hashedPassword });
    }

    public async Task<string> LoginAsync(LoginRequestDto loginRequest)
    {
        
        var user = await _userRepository.GetByUsernameAsync(loginRequest.Username);
        
        if(user == null)
            throw new Exception($"User not found[{loginRequest.Username}]");

        user.PasswordHash = _passwordHasher.GeneratePasswordHash("0000");

        var result = _passwordHasher.Verify(loginRequest.Password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Failed to login");
        }

        return _jwtProvider.GenerateJwtToken(user);
    }
}