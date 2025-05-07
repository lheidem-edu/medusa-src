using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class UserModel
{
    [JsonPropertyName("user_id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("user_tenant_id")]
    public required Guid TenantId { get; set; }

    [JsonPropertyName("user_email_address")]
    public required string EmailAddress { get; set; }

    [JsonPropertyName("user_created_at")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("user_updated_at")]
    public required DateTime UpdatedAt { get; init; }
}
