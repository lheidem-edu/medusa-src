using System.Text.Json.Serialization;

namespace Medusa.Presentation.Devices;

public class CreateDeviceModel
{
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
}
