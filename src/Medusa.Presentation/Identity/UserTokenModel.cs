using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class UserTokenModel
{
    [JsonPropertyName("user_token_id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("user_id")]
    public required Guid UserId { get; set; }

    [JsonPropertyName("user_token_user_agent")]
    public required string UserAgent { get; set; }

    [JsonPropertyName("user_token_expires_at")]
    public required DateTime ExpiresAt { get; set; }

    [JsonPropertyName("user_token_created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("user_token_updated_at")]
    public DateTime UpdatedAt { get; init; }
}
