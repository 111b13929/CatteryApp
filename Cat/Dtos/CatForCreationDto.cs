using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cat.Dtos
{
    public class CatForCreationDto
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsVaccinated { get; set; }
    }
}
