using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Schedules
{
    public class EditModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public EditModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Schedules Schedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule = await _context.Schedule
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(m => m.IdHorario == id);

            if (Schedule == null)
            {
                return NotFound();
            }

            ViewData["Course"] = new SelectList(_context.Course, "Id", "NombreCurso", Schedule.CoursesId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Course"] = new SelectList(_context.Course, "Id", "NombreCurso", Schedule.CoursesId);
                return Page();
            }

            _context.Attach(Schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(Schedule.IdHorario))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.IdHorario == id);
        }
    }
}
