using System.Security.Cryptography;
using System.Text;

namespace Medusa.Infrastructure.Identity;

public class TokenHasher : ITokenHasher
{
    private readonly byte[] _secret;

    public TokenHasher(string secret)
    {
        if (string.IsNullOrEmpty(secret))
        {
            throw new ArgumentException("Secret cannot be null or empty.", nameof(secret));
        }

        _secret = Encoding.UTF8.GetBytes(secret);
    }

    /// <inheritdoc />
    public string ComputeHash(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("Token cannot be null or empty.", nameof(token));
        }

        return Convert.ToBase64String(HMACSHA256.HashData(_secret, Encoding.UTF8.GetBytes(token)));
    }
}
