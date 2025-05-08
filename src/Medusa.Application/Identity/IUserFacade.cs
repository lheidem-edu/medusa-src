using Medusa.Presentation.Identity;

namespace Medusa.Application.Identity;

public interface IUserFacade
{
    /// <summary>
    ///     Retrieves a collection of users associated with the specified tenant.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns></returns>
    Task<IReadOnlyCollection<UserModel>> GetUsersAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserModel" /> object representing the user, or null if not found.</returns>
    Task<UserModel?> GetUserAsync(Guid tenantId, Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user by their email address.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="emailAddress">The email address of the user to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserModel" /> object representing the user, or null if not found.</returns>
    Task<UserModel?> GetUserByEmailAddressAsync(Guid tenantId, string emailAddress, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Logs in a user using their email address and password.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="model">The <see cref="LoginUserModel" /> object containing the user's login credentials.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A string representing the authentication token for the logged-in user.</returns>
    Task<string> LoginUserAsync(Guid tenantId, LoginUserModel model, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Registers a new user using their email address and password.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="model">The <see cref="RegisterUserModel" /> object containing the user's registration information.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A string representing the authentication token for the registered user.</returns>
    Task<string> RegisterUserAsync(Guid tenantId, RegisterUserModel model, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user profile by the user's unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user whose profile to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserProfileModel" /> object representing the user's profile, or null if not found.</returns>
    Task<UserProfileModel?> GetUserProfileAsync(Guid tenantId, Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new user profile for the specified user.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user.</param>
    /// <param name="model">The <see cref="CreateUserProfileModel" /> object representing the user profile to create.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserProfileModel" /> object representing the created user profile.</returns>
    Task<UserProfileModel> CreateUserProfileAsync(Guid tenantId, Guid userId, CreateUserProfileModel model, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing user profile for the specified user.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user whose profile to delete.</param>
    /// <param name="model">The <see cref="UpdateUserProfileModel" /> object representing the user profile to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    Task UpdateUserProfileAsync(Guid tenantId, Guid userId, UpdateUserProfileModel model, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a collection of user tokens associated with the specified user.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user whose tokens to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A collection of <see cref="UserTokenModel" /> objects representing the user's tokens.</returns>
    Task<IReadOnlyCollection<UserTokenModel>> GetUserTokensAsync(Guid tenantId, Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a user token by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user whose token to retrieve.</param>
    /// <param name="tokenId">The unique identifier for the token to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="UserTokenModel" /> object representing the user token, or null if not found.</returns>
    Task<UserTokenModel?> GetUserTokenAsync(Guid tenantId, Guid userId, Guid tokenId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a user token by its unique identifier.
    /// </summary>
    /// <param name="tenantId">The unique identifier for the tenant.</param>
    /// <param name="userId">The unique identifier for the user whose token to delete.</param>
    /// <param name="tokenId">The unique identifier for the token to delete.</param>
    /// <param name="cancellationToken">The cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    Task<bool> DeleteUserTokenAsync(Guid tenantId, Guid userId, Guid tokenId, CancellationToken cancellationToken = default);
}
