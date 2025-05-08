using Medusa.Domain.Identity;
using Medusa.Infrastructure.Identity;
using Medusa.Presentation.Identity;

namespace Medusa.Application.Identity;

public class UserFacade : IUserFacade
{
    private readonly IUserRepository _userRepository;

    private readonly ITokenFacade _tokenFacade;

    private readonly IPasswordHasher _passwordHasher;

    public UserFacade(IPasswordHasher passwordHasher, ITokenFacade tokenFacade, IUserRepository userRepository)

    {
        _userRepository = userRepository;
        _tokenFacade = tokenFacade;
        _passwordHasher = passwordHasher;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<UserModel>> GetUsersAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetUsersAsync(tenantId, cancellationToken);

        return users.Select(user => new UserModel
        {
            Id = user.Id,
            TenantId = user.TenantId,
            EmailAddress = user.EmailAddress,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        }).ToList();
    }

    /// <inheritdoc />
    public async Task<UserModel?> GetUserAsync(Guid tenantId, Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        return new UserModel
        {
            Id = user.Id,
            TenantId = user.TenantId,
            EmailAddress = user.EmailAddress,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<UserModel?> GetUserByEmailAddressAsync(Guid tenantId, string emailAddress, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserByEmailAddressAsync(tenantId, emailAddress, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with email address {emailAddress} not found.");
        }

        return new UserModel
        {
            Id = user.Id,
            TenantId = user.TenantId,
            EmailAddress = user.EmailAddress,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<string> LoginUserAsync(Guid tenantId, LoginUserModel model, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserByEmailAddressAsync(tenantId, model.EmailAddress, cancellationToken);

        if (user == null || user.TenantId != tenantId || !_passwordHasher.VerifyHash(model.Password, user.PasswordHash))
        {
            throw new KeyNotFoundException($"User with email address {model.EmailAddress} not found.");
        }

        var token = await _tokenFacade.GenerateTokenAsync(user, "TODO - useragent", cancellationToken);
        return token;
    }

    /// <inheritdoc />
    public async Task<string> RegisterUserAsync(Guid tenantId, RegisterUserModel model,
        CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.GetUserByEmailAddressAsync(tenantId, model.EmailAddress, cancellationToken);

        if (existingUser != null)
        {
            throw new InvalidOperationException($"User with email address {model.EmailAddress} already exists.");
        }

        var saltedHash = _passwordHasher.ComputeHash(model.Password);

        var user = new User
        {
            TenantId = tenantId,
            EmailAddress = model.EmailAddress,
            PasswordHash = saltedHash
        };

        await _userRepository.AddUserAsync(user, cancellationToken);

        var token = await _tokenFacade.GenerateTokenAsync(user, "TODO- useragent", cancellationToken);
        return token;
    }

    /// <inheritdoc />
    public async Task<UserProfileModel?> GetUserProfileAsync(Guid tenantId, Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        var profile = await _userRepository.GetUserProfileAsync(user.Id, cancellationToken);

        if (profile == null)
        {
            throw new KeyNotFoundException($"User profile for user with unique identifier {userId} not found.");
        }

        return new UserProfileModel
        {
            Id = profile.Id,
            UserId = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            CreatedAt = profile.CreatedAt,
            UpdatedAt = profile.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<UserProfileModel> CreateUserProfileAsync(Guid tenantId, Guid userId, CreateUserProfileModel model,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        var existingUserProfile = await _userRepository.GetUserProfileAsync(user.Id, cancellationToken);

        if (existingUserProfile != null)
        {
            throw new InvalidOperationException($"User profile for user with unique identifier {userId} already exists.");
        }

        var profile = new UserProfile
        {
            UserId = userId,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        await _userRepository.AddUserProfileAsync(profile, cancellationToken);

        return new UserProfileModel
        {
            Id = profile.Id,
            UserId = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            CreatedAt = profile.CreatedAt,
            UpdatedAt = profile.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task UpdateUserProfileAsync(Guid tenantId, Guid userId, UpdateUserProfileModel model,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        var profile = await _userRepository.GetUserProfileAsync(user.Id, cancellationToken);

        if (profile == null)
        {
            throw new KeyNotFoundException($"User profile for user with unique identifier {userId} not found.");
        }

        profile.FirstName = model.FirstName ?? profile.FirstName;
        profile.LastName = model.LastName ?? profile.LastName;

        profile.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateUserProfileAsync(profile, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<UserTokenModel>> GetUserTokensAsync(Guid tenantId, Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        var userTokens = await _userRepository.GetUserTokensAsync(user.Id, cancellationToken);

        return userTokens.Select(token => new UserTokenModel
        {
            Id = token.Id,
            UserId = token.UserId,
            UserAgent = token.UserAgent,
            ExpiresAt = token.ExpiresAt,
            CreatedAt = token.CreatedAt,
            UpdatedAt = token.UpdatedAt
        }).ToList();
    }

    /// <inheritdoc />
    public async Task<UserTokenModel?> GetUserTokenAsync(Guid tenantId, Guid userId, Guid tokenId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        var token = await _userRepository.GetUserTokenAsync(tokenId, cancellationToken);

        if (token == null || token.UserId != user.Id)
        {
            throw new KeyNotFoundException($"User token with unique identifier {tokenId} not found.");
        }

        return new UserTokenModel
        {
            Id = token.Id,
            UserId = token.UserId,
            UserAgent = token.UserAgent,
            ExpiresAt = token.ExpiresAt,
            CreatedAt = token.CreatedAt,
            UpdatedAt = token.UpdatedAt
        };
    }

    /// <inheritdoc />
    public async Task<bool> DeleteUserTokenAsync(Guid tenantId, Guid userId, Guid tokenId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetUserAsync(userId, cancellationToken);

        if (user == null || user.TenantId != tenantId)
        {
            throw new KeyNotFoundException($"User with unique identifier {userId} not found.");
        }

        var token = await _userRepository.GetUserTokenAsync(tokenId, cancellationToken);

        if (token == null || token.UserId != user.Id)
        {
            throw new KeyNotFoundException($"User token with unique identifier {tokenId} not found.");
        }

        var result = await _userRepository.DeleteUserTokenAsync(token.Id, cancellationToken);
        return result;
    }
}
