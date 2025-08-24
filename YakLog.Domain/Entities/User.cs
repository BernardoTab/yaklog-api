namespace YakLogApi.Entities;

public class User
{
    public long Id { get; set; }
    public required string Email { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public required byte[] PasswordHash { get; set; }
    public string? ImageFilePath { get; set; }
}
