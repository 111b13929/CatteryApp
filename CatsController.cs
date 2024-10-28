using Cat.Dtos;
using Cat.Interfaces;
using Cat.Models; // Add this line to include the Cat model
using Microsoft.AspNetCore.Mvc;

namespace Cat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatRepository _repository;

        public CatsController(ICatRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cat = await _repository.GetByIdAsync(id);
            return cat == null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatForCreationDto dto)
        {
            var cat = new Cat
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Age = dto.Age,
                IsVaccinated = dto.IsVaccinated
            };
            await _repository.AddAsync(cat);
            return CreatedAtAction(nameof(GetById), new { id = cat.Id }, cat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CatForUpdateDto dto)
        {
            var cat = await _repository.GetByIdAsync(id);
            if (cat == null) return NotFound();

            cat.Name = dto.Name ?? cat.Name;
            cat.Age = dto.Age != 0 ? dto.Age : cat.Age;
            cat.Breed = dto.Breed ?? cat.Breed;
            cat.IsVaccinated = dto.IsVaccinated;
            cat.Description = dto.Description ?? cat.Description;

            await _repository.UpdateAsync(cat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) =>
            await _repository.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
