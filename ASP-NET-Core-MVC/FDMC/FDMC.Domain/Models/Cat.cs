using System.ComponentModel.DataAnnotations;

namespace FDMC.Domain.Models
{
    public class Cat
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
