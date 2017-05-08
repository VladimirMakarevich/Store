using Newtonsoft.Json;

namespace Store.Api.Models
{
    public class RegistrationUser
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}