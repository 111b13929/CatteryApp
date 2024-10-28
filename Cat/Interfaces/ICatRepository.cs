using System.Collections.Generic;
using System.Threading.Tasks;
using System; // 確保引入 Guid

namespace CatteryApp.Interfaces
{
    public interface ICatRepository
    {
        Task<IEnumerable<CatteryApp.Models.Cat>> GetAllAsync(); // 使用完全限定名稱
        Task<CatteryApp.Models.Cat> GetByIdAsync(Guid id);      // 使用完全限定名稱
        Task<CatteryApp.Models.Cat> AddAsync(CatteryApp.Models.Cat cat); // 使用完全限定名稱
        Task<CatteryApp.Models.Cat> UpdateAsync(CatteryApp.Models.Cat cat); // 使用完全限定名稱
        Task<bool> DeleteAsync(Guid id);
    }
}
