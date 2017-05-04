using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities
{
    public class PurchaseHistory
    {
        [Key]
        public int Id { get; set; }

        public State State { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
