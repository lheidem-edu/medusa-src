using System.Text.Json.Serialization;

namespace Medusa.Presentation.Devices;

public class DeviceModel
{
    [JsonPropertyName("device_id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("device_tenant_id")]
    public required Guid TenantId { get; set; }

    [JsonPropertyName("device_serial_number")]
    public required string SerialNumber { get; set; }

    [JsonPropertyName("device_name")]
    public required string Name { get; set; }

    [JsonPropertyName("device_description")]
    public string? Description { get; set; }

    [JsonPropertyName("device_location")]
    public string? Location { get; set; }

    [JsonPropertyName("device_created_at")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("device_updated_at")]
    public required DateTime UpdatedAt { get; init; }
}
