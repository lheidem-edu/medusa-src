using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Identity;

/// <summary>
///     Represents a user token in the system.
/// </summary>
[Table("user_tokens", Schema = "public")]
public class UserToken : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier of the token.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier of the user associated with this token.
    /// </summary>
    public required Guid UserId { get; set; }

    /// <summary>
    ///     The token hash.
    /// </summary>
    public required string Hash { get; set; }

    /// <summary>
    ///     The date and time when the token expires.
    /// </summary>
    public required DateTime ExpiresAt { get; set; }

    /// <summary>
    ///     The date and time when the token was created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the token was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
