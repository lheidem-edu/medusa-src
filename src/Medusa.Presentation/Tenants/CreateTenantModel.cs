using System.Text.Json.Serialization;

namespace Medusa.Presentation.Tenants;

public class CreateTenantModel
{
    [JsonPropertyName("tenant_country")]
    public required string Country { get; set; }

    [JsonPropertyName("tenant_name")]
    public required string Name { get; set; }
}
