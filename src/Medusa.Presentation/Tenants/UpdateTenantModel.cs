using System.Text.Json.Serialization;

namespace Medusa.Presentation.Tenants;

public class UpdateTenantModel
{
    [JsonPropertyName("tenant_country")]
    public string? Country { get; set; }

    [JsonPropertyName("tenant_name")]
    public string? Name { get; set; }
}
