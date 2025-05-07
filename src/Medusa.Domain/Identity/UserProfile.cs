using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Identity;

/// <summary>
///     This class represents a user profile in the system.
/// </summary>
[Table("user_profiles", Schema = "public")]
public class UserProfile : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the user profile.
    /// </summary>
    [Column("user_profile_id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier for the user to whom this profile belongs.
    /// </summary>
    [Column("user_id")]
    public required Guid UserId { get; set; }

    /// <summary>
    ///     The first name of the user.
    /// </summary>
    [Column("user_profile_first_name")]
    public required string FirstName { get; set; }

    /// <summary>
    ///     The last name of the user.
    /// </summary>
    [Column("user_profile_last_name")]
    public required string LastName { get; set; }

    /// <summary>
    ///     The date and time when the user profile was created.
    /// </summary>
    [Column("user_profile_created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the user profile was last updated.
    /// </summary>
    [Column("user_profile_updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
