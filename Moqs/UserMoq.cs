using FinSystem.Entities;

namespace FinSystem.Moqs;

public static class UserMoq
{
    private static List<User> Users { get; set; } = [new User() { Username = "Admin", Role = 0, PasswordHash = "$2b$12$5cIPo96oX1ZE.X9/t7G56O7M4LfD6w00OglvIWwJFrEGASMPARS8e" }];

    public static async Task AddUserAsync(string username, string passwordHash, int role = 1)
    {
        await Task.Delay(300);
        
        if(Users.FirstOrDefault(u=>u.Username == username) is not null)
            throw new Exception("Username already exists");
        
        Users.Add(new User() {Username = username, PasswordHash = passwordHash, Role = role});
    }

    public static async Task<User> GetUserAsync(string username)
    {
        await Task.Delay(100);
        return Users.FirstOrDefault(u => u.Username == username);
    }
}