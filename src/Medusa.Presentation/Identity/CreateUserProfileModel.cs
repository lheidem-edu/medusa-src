using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class CreateUserProfileModel
{
    [JsonPropertyName("user_profile_first_name")]
    public required string FirstName { get; set; }

    [JsonPropertyName("user_profile_last_name")]
    public required string LastName { get; set; }
}
