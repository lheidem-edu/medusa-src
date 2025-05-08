using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class RegisterUserModel
{
    [JsonPropertyName("register_user_email_address")]
    public required string EmailAddress { get; set; }

    [JsonPropertyName("register_user_password")]
    public required string Password { get; set; }
}
