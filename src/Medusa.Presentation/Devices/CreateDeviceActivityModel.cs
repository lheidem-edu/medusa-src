using System.Text.Json.Serialization;

namespace Medusa.Presentation.Devices;

public class CreateDeviceActivityModel
{
    [JsonPropertyName("device_id")]
    public required Guid DeviceId { get; set; }

    [JsonPropertyName("device_activity_type")]
    public required string Type { get; set; }
}
