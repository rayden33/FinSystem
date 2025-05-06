namespace FinSystem.Entities;

public class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int Role { get; set; }
}