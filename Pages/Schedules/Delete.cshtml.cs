using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Schedules
{
    public class DeleteModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public DeleteModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Schedules Schedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Schedule = await _context.Schedule
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(m => m.IdHorario == id);

            if (Schedule == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Schedule = await _context.Schedule.FindAsync(id);

            if (Schedule != null)
            {
                _context.Schedule.Remove(Schedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
