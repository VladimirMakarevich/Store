using Newtonsoft.Json;

namespace Store.Api.Models
{
    public class ProductJsonModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Price")]
        public decimal Price { get; set; }
    }
}