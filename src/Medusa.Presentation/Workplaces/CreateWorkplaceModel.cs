using System.Text.Json.Serialization;

namespace Medusa.Presentation.Workplaces;

public class CreateWorkplaceModel
{
    [JsonPropertyName("workplace_tenant_id")]
    public required Guid TenantId { get; set; }

    [JsonPropertyName("workplace_enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("workplace_name")]
    public required string Name { get; set; }
}
