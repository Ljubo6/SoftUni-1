namespace Musaca.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
