using CatteryApp.Data;
using CatteryApp.Interfaces;
using CatteryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatteryApp.Repositories
{
    public class CatRepository : ICatRepository
    {
        private readonly AppDbContext _context;

        public CatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatteryApp.Models.Cat>> GetAllAsync() => await _context.Cats.ToListAsync();

        public async Task<CatteryApp.Models.Cat> GetByIdAsync(Guid id) => await _context.Cats.FindAsync(id);

        public async Task<CatteryApp.Models.Cat> AddAsync(CatteryApp.Models.Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();
            return cat;
        }

        public async Task<CatteryApp.Models.Cat> UpdateAsync(CatteryApp.Models.Cat cat)
        {
            _context.Cats.Update(cat);
            await _context.SaveChangesAsync();
            return cat;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat == null) return false;

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
