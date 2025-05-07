using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Identity;

/// <summary>
///     This class represents a user in the system.
/// </summary>
[Table("users", Schema = "public")]
public class User : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the user.
    /// </summary>
    [Column("user_id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier for the tenant to which the user belongs.
    /// </summary>
    [Column("user_tenant_id")]
    public required Guid TenantId { get; set; }

    /// <summary>
    ///     The email address of the user.
    /// </summary>
    [Column("user_email_address")]
    public required string EmailAddress { get; set; }

    /// <summary>
    ///     The password hash of the user.
    /// </summary>
    [Column("user_password_hash")]
    public required string PasswordHash { get; set; }

    /// <summary>
    ///     The date and time when the user was created.
    /// </summary>
    [Column("user_created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the user was last updated.
    /// </summary>
    [Column("user_updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
