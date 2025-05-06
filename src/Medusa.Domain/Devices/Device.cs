using System.ComponentModel.DataAnnotations.Schema;

namespace Medusa.Domain.Devices;

/// <summary>
///     This class represents a device in the system.
/// </summary>
[Table("devices", Schema = "public")]
public class Device : IAuditable, IIdentifiable
{
    /// <summary>
    ///     The unique identifier for the device.
    /// </summary>
    [Column("device_id")]
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     The unique identifier for the tenant associated with this device.
    /// </summary>
    [Column("device_tenant_id")]
    public required Guid TenantId { get; set; }

    /// <summary>
    ///     The serial number of the device.
    /// </summary>
    [Column("device_serial_number")]
    public required string SerialNumber { get; set; }

    /// <summary>
    ///     The name of the device.
    /// </summary>
    [Column("device_name")]
    public required string Name { get; set; }

    /// <summary>
    ///     The description of the device.
    /// </summary>
    [Column("device_description")]
    public string? Description { get; set; }

    /// <summary>
    ///     The location of the device.
    /// </summary>
    [Column("device_location")]
    public string? Location { get; set; }

    /// <summary>
    ///     The date and time when the device was created.
    /// </summary>
    [Column("device_created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    ///     The date and time when the device was last updated.
    /// </summary>
    [Column("device_updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
