using System.Security.Cryptography;
using Medusa.Domain.Identity;
using Medusa.Infrastructure.Identity;

namespace Medusa.Application.Identity;

public class TokenFacade : ITokenFacade
{
    private const int EXPIRATION_TIME_MINUTES = 480;

    private readonly IUserRepository _userRepository;
    private readonly ITokenHasher _tokenHasher;

    public TokenFacade(IUserRepository userRepository, ITokenHasher tokenHasher)
    {
        _userRepository = userRepository;
        _tokenHasher = tokenHasher;
    }

    /// <inheritdoc />
    public async Task<string> GenerateTokenAsync(User user, string userAgent, CancellationToken cancellationToken = default)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var hash = _tokenHasher.ComputeHash(token);

        var userToken = new UserToken
        {
            UserId = user.Id,
            Digest = hash,
            UserAgent = userAgent,
            ExpiresAt = DateTime.UtcNow.AddMinutes(EXPIRATION_TIME_MINUTES)
        };

        await _userRepository.AddUserTokenAsync(userToken, cancellationToken);

        return token;
    }

    /// <inheritdoc />
    public async Task<User?> ValidateTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        var hash = _tokenHasher.ComputeHash(token);

        var userToken = await _userRepository.GetUserTokenByDigestAsync(hash, cancellationToken);

        if (userToken == null || userToken.ExpiresAt < DateTime.UtcNow)
        {
            return null;
        }

        var user = await _userRepository.GetUserAsync(userToken.UserId, cancellationToken);
        return user;
    }
}
