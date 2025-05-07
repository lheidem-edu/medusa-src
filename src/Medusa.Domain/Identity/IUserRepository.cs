namespace Medusa.Domain.Identity;

/// <summary>
///     A repository interface for managing user entities.
/// </summary>
public interface IUserRepository
{
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
    /// <param name="userProfile">The <see cref="UserProfile" /> object representing the user profile to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The added <see cref="UserProfile" /> object.</returns>
    Task<UserProfile> AddUserProfileAsync(UserProfile userProfile, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing user profile.
    /// </summary>
    /// <param name="userProfile">The <see cref="UserProfile" /> object representing the user profile to update.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateUserProfileAsync(UserProfile userProfile, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a user profile by its unique identifier.
    /// </summary>
    /// <param name="userProfileId">The unique identifier of the user profile to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteUserProfileAsync(Guid userProfileId, CancellationToken cancellationToken = default);
}
