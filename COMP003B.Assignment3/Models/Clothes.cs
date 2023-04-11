using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class Clothes
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Price { get; set; }    
    }
}
