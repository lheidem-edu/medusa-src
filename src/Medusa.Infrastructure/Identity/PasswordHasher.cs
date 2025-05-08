using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Medusa.Infrastructure.Identity;

public class PasswordHasher : IPasswordHasher
{
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;

    private const int ARGON2_DEGREE_OF_PARALLELISM = 2;
    private const int ARGON2_MEMORY_SIZE = 65536; // 64 MB
    private const int ARGON2_ITERATIONS = 4;

    /// <inheritdoc />
    public string ComputeHash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }

        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            DegreeOfParallelism = ARGON2_DEGREE_OF_PARALLELISM,
            MemorySize = ARGON2_MEMORY_SIZE,
            Iterations = ARGON2_ITERATIONS,
            Salt = salt,
        };

        var hash = argon2.GetBytes(HASH_SIZE);

        var computed = new byte[SALT_SIZE + HASH_SIZE];

        Buffer.BlockCopy(salt, 0, computed, 0, SALT_SIZE);
        Buffer.BlockCopy(hash, 0, computed, SALT_SIZE, HASH_SIZE);

        var saltedHash = Convert.ToBase64String(computed);

        return saltedHash;
    }

    /// <inheritdoc />
    public bool VerifyHash(string password, string saltedHash)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        }

        if (string.IsNullOrWhiteSpace(saltedHash))
        {
            throw new ArgumentException("Salted hash cannot be null or empty.", nameof(saltedHash));
        }

        var stored = Convert.FromBase64String(saltedHash);

        if (stored.Length != SALT_SIZE + HASH_SIZE)
        {
            throw new FormatException("Invalid hash format.");
        }

        var salt = new byte[SALT_SIZE];
        var hash = new byte[HASH_SIZE];

        Buffer.BlockCopy(hash, 0, salt, 0, SALT_SIZE);
        Buffer.BlockCopy(hash, SALT_SIZE, hash, 0, HASH_SIZE);

        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            DegreeOfParallelism = ARGON2_DEGREE_OF_PARALLELISM,
            MemorySize = ARGON2_MEMORY_SIZE,
            Iterations = ARGON2_ITERATIONS,
            Salt = salt,
        };

        var computed = argon2.GetBytes(HASH_SIZE);

        for (int i = 0; i < HASH_SIZE; i++)
        {
            if (computed[i] != hash[i])
            {
                return false;
            }
        }

        return true;
    }
}
