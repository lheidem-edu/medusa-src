namespace Medusa.Application.Identity;

public interface IPasswordFacade
{
    /// <summary>
    ///     Hashes the password using bcrypt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password.</returns>
    string HashPassword(string password);

    /// <summary>
    ///     Verifies the password against the hashed password.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="hash">The hashed password.</param>
    /// <returns>A boolean indicating whether the password is valid.</returns>
    bool VerifyPassword(string password, string hash);
}
