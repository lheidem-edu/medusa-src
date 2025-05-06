using System.Text.Json.Serialization;

namespace Medusa.Presentation.Tenants;

public class TenantModel
{
    [JsonPropertyName("tenant_id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("tenant_country")]
    public required string Country { get; set; }

    [JsonPropertyName("tenant_name")]
    public required string Name { get; set; }

    [JsonPropertyName("tenant_created_at")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("tenant_updated_at")]
    public required DateTime UpdatedAt { get; init; }
}
