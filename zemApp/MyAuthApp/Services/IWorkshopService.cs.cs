using MyAuthApp.Data;  

namespace MyAuthApp.Services
{
    public interface IWorkshopService
    {
        Task<IEnumerable<Workshop>> GetAllAsync();
        Task<Workshop?> GetByIdAsync(int id);
        Task<Workshop> CreateAsync(Workshop workshop);
        Task<bool> UpdateAsync(int id, Workshop updatedWorkshop);
        Task<bool> DeleteAsync(int id);
    }
}
