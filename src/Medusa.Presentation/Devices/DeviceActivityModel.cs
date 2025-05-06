using System.Text.Json.Serialization;

namespace Medusa.Presentation.Devices;

public class DeviceActivityModel
{
    [JsonPropertyName("device_activity_id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("device_id")]
    public required Guid DeviceId { get; set; }

    [JsonPropertyName("device_activity_type")]
    public required string Type { get; set; }

    [JsonPropertyName("device_activity_created_at")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("device_activity_updated_at")]
    public required DateTime UpdatedAt { get; set; }
}
