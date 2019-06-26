namespace Eventures.App.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateEventInputModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TotalTickets { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage ="Price must be positive!")]
        public decimal PricePerTicket { get; set; }
    }
}
