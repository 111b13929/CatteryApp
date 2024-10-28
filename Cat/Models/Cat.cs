using System.ComponentModel.DataAnnotations;

namespace CatteryApp.Models
{
    public class Cat
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public string? Breed { get; set; }

        [Required]
        public bool IsVaccinated { get; set; }

        public string? Description { get; set; }
    }
}
