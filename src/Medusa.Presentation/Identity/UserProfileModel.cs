using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class UserProfileModel
{
    [JsonPropertyName("user_profile_id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("user_id")]
    public required Guid UserId { get; set; }

    [JsonPropertyName("user_profile_first_name")]
    public required string FirstName { get; set; }

    [JsonPropertyName("user_profile_last_name")]
    public required string LastName { get; set; }

    [JsonPropertyName("user_profile_created_at")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("user_profile_updated_at")]
    public required DateTime UpdatedAt { get; init; }
}
