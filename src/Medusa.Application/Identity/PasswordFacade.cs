namespace Medusa.Application.Identity;

public class PasswordFacade : IPasswordFacade
{
    private const int WORK_FACTOR = 12;

    /// <inheritdoc />
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, WORK_FACTOR);
    }

    /// <inheritdoc />
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
