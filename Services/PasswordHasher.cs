namespace FinSystem.Services;

public class PasswordHasher
{
    public string GeneratePasswordHash(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    
    public bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}