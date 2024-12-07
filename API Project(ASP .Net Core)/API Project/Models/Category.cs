using System.ComponentModel.DataAnnotations;

namespace API_Project.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
