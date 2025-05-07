namespace Medusa.Infrastructure.Identity;

public interface IPasswordHasher
{
    /// <summary>
    ///     Hashes a password using bcrypt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password.</returns>
    string ComputeHash(string password);

    /// <summary>
    ///     Verifies a password against a hashed password using bcrypt.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="hashedPassword">The hashed password to verify against.</param>
    /// <returns>A boolean indicating whether the password matches the hashed password.</returns>
    bool VerifyHash(string password, string hashedPassword);
}
