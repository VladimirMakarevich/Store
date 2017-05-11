using Newtonsoft.Json;

namespace Store.Api.Models
{
    public class PaymentPaypalJsonModel
    {
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
        [JsonProperty("Url")]
        public string Url { get; set; }
    }
}