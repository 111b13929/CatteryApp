using CatteryApp.Interfaces;
using CatteryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CatteryApp.Controllers
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
        public async Task<IActionResult> Create(CatteryApp.Models.Cat cat) // 使用完全限定名稱
        {
            var newCat = await _repository.AddAsync(cat);
            return CreatedAtAction(nameof(GetById), new { id = newCat.Id }, newCat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CatteryApp.Models.Cat cat) // 使用完全限定名稱
        {
            var existingCat = await _repository.GetByIdAsync(id);
            if (existingCat == null) return NotFound();

            existingCat.Name = cat.Name;
            existingCat.Age = cat.Age;
            existingCat.Breed = cat.Breed;
            existingCat.IsVaccinated = cat.IsVaccinated;
            existingCat.Description = cat.Description;

            await _repository.UpdateAsync(existingCat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
