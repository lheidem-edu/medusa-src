using System.Text.Json.Serialization;

namespace Medusa.Presentation.Workplaces;

public class UpdateWorkplaceModel
{
    [JsonPropertyName("workplace_tenant_id")]
    public Guid? TenantId { get; set; }

    [JsonPropertyName("workplace_enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("workplace_name")]
    public string? Name { get; set; }
}
