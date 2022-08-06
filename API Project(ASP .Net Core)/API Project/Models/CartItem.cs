using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Project.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalCost { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Cart")]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; } = new Cart();
    }
}
