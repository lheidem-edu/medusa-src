using System.Text.Json.Serialization;

namespace Medusa.Presentation.Identity;

public class LoginUserModel
{
    [JsonPropertyName("login_user_email_address")]
    public required string EmailAddress { get; set; }

    [JsonPropertyName("login_user_password")]
    public required string Password { get; set; }
}
