using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class UpdateUserProfileModel
{
    [JsonPropertyName("user_profile_first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("user_profile_last_name")]
    public string? LastName { get; set; }
}
