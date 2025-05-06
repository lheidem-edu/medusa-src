using System.Text.Json.Serialization;

namespace Medusa.Presentation.Workplaces;

public class WorkplaceModel
{
    [JsonPropertyName("workplace_id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("workplace_tenant_id")]
    public required Guid TenantId { get; set; }

    [JsonPropertyName("workplace_enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("workplace_name")]
    public required string Name { get; set; }

    [JsonPropertyName("workplace_created_at")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("workplace_updated_at")]
    public required DateTime UpdatedAt { get; init; }
}
