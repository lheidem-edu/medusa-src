using Medusa.Domain.Identity;

namespace Medusa.Application.Identity;

public interface ITokenFacade
{
    /// <summary>
    ///     Generates a token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom to generate the token.</param>
    /// <param name="userAgent">The user agent string of the client that is generating the token.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The generated token as a string.</returns>
    Task<string> GenerateTokenAsync(User user, string userAgent, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Validates the specified token and retrieves the associated user.
    /// </summary>
    /// <param name="token">The token to validate.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The user associated with the token, or null if the token is invalid.</returns>
    Task<User?> ValidateTokenAsync(string token, CancellationToken cancellationToken = default);
}
