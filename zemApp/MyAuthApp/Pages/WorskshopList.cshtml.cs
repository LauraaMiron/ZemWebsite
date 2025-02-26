using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAuthApp.Data;
using MyAuthApp.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyAuthApp.Pages
{
    public class WorkshopListModel : PageModel
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopListModel(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        public string Username { get; set; } = "User"; 
        public List<Workshop> Workshops { get; set; } = new();

        [BindProperty]
        public Workshop NewWorkshop { get; set; } = new();

        [BindProperty]
        public Workshop EditWorkshop { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Workshops = (await _workshopService.GetAllAsync()) as List<Workshop> ?? new List<Workshop>();
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
            {
                Workshops = (await _workshopService.GetAllAsync()) as List<Workshop> ?? new List<Workshop>();
                return Page(); 
            }

            await _workshopService.CreateAsync(NewWorkshop);

            return RedirectToPage(); 
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _workshopService.DeleteAsync(id);

            return RedirectToPage();}




       public async Task<IActionResult> OnPostUpdateAsync()
{
    if (!ModelState.IsValid)
    {
        Workshops = (await _workshopService.GetAllAsync()) as List<Workshop> ?? new List<Workshop>();
        return Page(); 
    }

    var existingWorkshop = await _workshopService.GetByIdAsync(EditWorkshop.Id);
    if (existingWorkshop == null) return NotFound(); 

    existingWorkshop.Name = EditWorkshop.Name;
    existingWorkshop.Description = EditWorkshop.Description;
    existingWorkshop.DateTime = EditWorkshop.DateTime;
    existingWorkshop.Category = EditWorkshop.Category;

    await _workshopService.UpdateAsync(existingWorkshop.Id, existingWorkshop);

    return RedirectToPage(); 
}

    }
}
