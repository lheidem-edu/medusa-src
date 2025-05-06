using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Devices;

/// <summary>
///     This class represents a device activity in the system.
/// </summary>
[Table("device_activities", Schema = "public")]
public class DeviceActivity : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the device activity.
    /// </summary>
    [Column("device_activity_id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier for the device associated with this activity.
    /// </summary>
    [Column("device_id")]
    public required Guid DeviceId { get; set; }

    /// <summary>
    ///     The type of activity performed on the device.
    /// </summary>
    [Column("device_activity_type")]
    public required string Type { get; set; }

    /// <summary>
    ///     The date and time when the device activity was created.
    /// </summary>
    [Column("device_activity_created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the device activity was last updated.
    /// </summary>
    [Column("device_activity_updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
