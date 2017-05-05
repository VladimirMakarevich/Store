using Newtonsoft.Json;

namespace Store.Web.Models
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