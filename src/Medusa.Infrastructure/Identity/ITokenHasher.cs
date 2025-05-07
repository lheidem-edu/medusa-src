namespace Medusa.Infrastructure.Identity;

public interface ITokenHasher
{
    /// <summary>
    ///     Hashes a token using HMAC SHA256.
    /// </summary>
    /// <param name="token">The token to hash.</param>
    /// <returns>The hashed token.</returns>
    string ComputeHash(string token);
}
