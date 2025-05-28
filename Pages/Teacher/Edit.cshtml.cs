using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerWeb.Models;
using EduCenterManagerWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Teacher
{
    public class EditModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public EditModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Teachers Teachers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (teacher == null)
            {
                return NotFound();
            }
            Teachers = teacher;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Teachers).State = EntityState.Modified;
    
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(Teachers.IdProfesor))
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

        private bool TeachersExists(int id)
        {
            return (_context.Teacher?.Any(e => e.IdProfesor == id)).GetValueOrDefault();
        }

    }
}
