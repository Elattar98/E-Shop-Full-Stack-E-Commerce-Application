using System.ComponentModel.DataAnnotations;

namespace API_Project.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public float TotalCost { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
}
