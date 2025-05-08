namespace Medusa.Infrastructure.Identity;

public class PasswordHasher : IPasswordHasher
{
    private const int WORK_FACTOR = 12;

    /// <inheritdoc />
    public string ComputeHash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }

        return BCrypt.Net.BCrypt.HashPassword(password, WORK_FACTOR);
    }

    /// <inheritdoc />
    public bool VerifyHash(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }

        if (string.IsNullOrWhiteSpace(hash))
        {
            throw new ArgumentException("Hash cannot be null or empty.", nameof(hash));
        }

        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
