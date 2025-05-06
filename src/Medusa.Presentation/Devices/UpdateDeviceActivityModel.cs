using System.Text.Json.Serialization;

namespace Medusa.Presentation.Devices;

public class UpdateDeviceActivityModel
{
    [JsonPropertyName("device_id")]
    public Guid? DeviceId { get; set; }

    [JsonPropertyName("device_activity_type")]
    public string? Type { get; set; }
}
