using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Availability Availability { get; set; }
    }
}
