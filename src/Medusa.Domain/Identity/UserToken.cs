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
    [Column("user_token_id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier of the user associated with this token.
    /// </summary>
    [Column("user_id")]
    public required Guid UserId { get; set; }

    /// <summary>
    ///     The token hash.
    /// </summary>
    [Column("user_token_digest")]
    public required string Digest { get; set; }

    /// <summary>
    ///     The user agent string of the client that created the token.
    /// </summary>
    [Column("user_token_user_agent")]
    public required string UserAgent { get; set; }

    /// <summary>
    ///     The date and time when the token expires.
    /// </summary>
    [Column("user_token_expires_at")]
    public required DateTime ExpiresAt { get; set; }


    /// <summary>
    ///     The date and time when the token was created.
    /// </summary>
    [Column("user_token_created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the token was last updated.
    /// </summary>
    [Column("user_token_updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
