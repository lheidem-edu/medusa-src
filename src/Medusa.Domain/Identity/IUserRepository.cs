namespace Medusa.Domain.Identity;

/// <summary>
///     A repository interface for managing user entities.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    ///     Retrieves all users associated with a specific tenant.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant whose users to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="User" /> objects representing all users associated with the specified tenant.</returns>
    Task<IReadOnlyCollection<User>> GetUsersAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user by its unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="User" /> object representing the user with the specified identifier, or null if not found.</returns>
    Task<User?> GetUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user by its email address.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to which the user belongs.</param>
    /// <param name="emailAddress">The email address of the user to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="User" /> object representing the user with the specified email address, or null if not found.</returns>
    Task<User?> GetUserByEmailAddressAsync(Guid tenantId, string emailAddress, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new user.
    /// </summary>
    /// <param name="user">The <see cref="User" /> object representing the user to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="User" /> object.</returns>
    Task<User> AddUserAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing user.
    /// </summary>
    /// <param name="user">The <see cref="User" /> object representing the user to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateUserAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a user by its unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user profile by the user's unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose profile to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserProfile" /> object representing the user's profile, or null if not found.</returns>
    Task<UserProfile?> GetUserProfileAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new user profile.
    /// </summary>
    /// <param name="profile">The <see cref="UserProfile" /> object representing the user profile to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="UserProfile" /> object.</returns>
    Task<UserProfile> AddUserProfileAsync(UserProfile profile, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing user profile.
    /// </summary>
    /// <param name="profile">The <see cref="UserProfile" /> object representing the user profile to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateUserProfileAsync(UserProfile profile, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a user profile by its unique identifier.
    /// </summary>
    /// <param name="profileId">The unique identifier of the user profile to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteUserProfileAsync(Guid profileId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves all user tokens associated with a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose tokens to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="UserToken" /> objects representing all tokens associated with the specified user.</returns>
    Task<IReadOnlyCollection<UserToken>> GetUserTokensAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user token by its unique identifier.
    /// </summary>
    /// <param name="tokenId">The unique identifier of the token to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserToken" /> object representing the user token with the specified identifier, or null if not found.</returns>
    Task<UserToken?> GetUserTokenAsync(Guid tokenId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user token by its hash.
    /// </summary>
    /// <param name="hash">The hash of the user token to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserToken" /> object representing the user token with the specified hash, or null if not found.</returns>
    Task<UserToken?> GetUserTokenByHashAsync(string hash, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Adds a new user token.
    /// </summary>
    /// <param name="token">The <see cref="UserToken" /> object representing the user token to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="UserToken" /> object.</returns>
    Task<UserToken> AddUserTokenAsync(UserToken token, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing user token.
    /// </summary>
    /// <param name="token">The <see cref="UserToken" /> object representing the user token to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateUserTokenAsync(UserToken token, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a user token by its unique identifier.
    /// </summary>
    /// <param name="tokenId">The unique identifier of the user token to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteUserTokenAsync(Guid tokenId, CancellationToken cancellationToken = default);
}
