namespace Medusa.Infrastructure.Identity;

public interface IPasswordHasher
{
    /// <summary>
    ///     Hashes a password using argon2.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The hashed password.</returns>
    Task<string> ComputeHash(string password, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Verifies a password against a hashed password using argon2.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="saltedHash">The hash to verify against.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the password matches the hashed password.</returns>
    Task<bool> VerifyHash(string password, string saltedHash, CancellationToken cancellationToken = default);
}
