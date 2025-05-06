using System.Text.Json.Serialization;

namespace Medusa.Presentation.Devices;

public class CreateDeviceActivityModel
{
    [JsonPropertyName("device_activity_type")]
    public required string Type { get; set; }
}
