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
    public bool VerifyHash(string password, string hashedPassword)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }

        if (string.IsNullOrWhiteSpace(hashedPassword))
        {
            throw new ArgumentException("Hashed password cannot be null or empty.", nameof(hashedPassword));
        }

        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
