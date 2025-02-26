using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyAuthApp.Data;

namespace MyAuthApp.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly AppDbContext _context;
        public WorkshopService(AppDbContext context){
            _context=context;
        }

        public async Task<IEnumerable<Workshop>> GetAllAsync()
        {
            return await _context.Workshops.ToListAsync();
        }

        public async Task<Workshop?> GetByIdAsync(int id){
            return await _context.Workshops.FindAsync(id);
        }

        public async Task<Workshop> CreateAsync(Workshop workshop){
            _context.Workshops.Add(workshop);
            await _context.SaveChangesAsync();
            return workshop;
        }

        public async Task<bool> DeleteAsync(int id){
            var workshop =  await _context.Workshops.FindAsync(id);
            if(workshop == null) return false;

            _context.Workshops.Remove(workshop);
            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<bool> UpdateAsync(int id, Workshop updatedWorkshop)
        {
            var workshop = await _context.Workshops.FindAsync(id);
            if (workshop == null) return false;

            workshop.Name = updatedWorkshop.Name;
            workshop.Description = updatedWorkshop.Description;
            workshop.DateTime = updatedWorkshop.DateTime;
            workshop.AdditionalInfo = updatedWorkshop.AdditionalInfo;
            workshop.Category = updatedWorkshop.Category;

            _context.Workshops.Update(workshop);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
