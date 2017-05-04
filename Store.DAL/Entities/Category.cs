using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DAL.Entities
{
    public class Category
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
