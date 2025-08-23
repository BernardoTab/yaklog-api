namespace YakLogApi.Entities;

public class User
{
    public long Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordSalt { get; set; }
    public required string PasswordHash { get; set; }
    public string? ImageFilePath { get; set; }
}
