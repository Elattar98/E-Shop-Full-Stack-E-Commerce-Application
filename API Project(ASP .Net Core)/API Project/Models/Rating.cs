using System.ComponentModel.DataAnnotations;

namespace API_Project.Models
{
    public class Rating
    {
        [Key]
        public int RId { get; set; }
        public float rate { get; set; }
        public int count { get; set; }
    }
}
