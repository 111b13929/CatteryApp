using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cat.Dtos
{
    public class CatForUpdateDto
    {
        [StringLength(10)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string? Breed { get; set; }

        public bool IsVaccinated { get; set; }

        public string? Description { get; set; }
    }
}
