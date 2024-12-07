using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Project.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        public float PPrice { get; set; }
        public string PTitle { get; set; }
        public string PDescription { get; set; }
        public string PImage { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }

        [ForeignKey("Rating")]
        public int? RatingId { get; set; }
        public virtual Rating Rating { get; set; } = new Rating() { rate=0, count=0};
    }
}
