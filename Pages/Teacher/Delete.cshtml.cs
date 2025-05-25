using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerWeb.Models;
using EduCenterManagerWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Teacher
{
    public class DeleteModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public DeleteModel(EduCenterManagerContext context)
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
            else
            {
                Teachers = teacher;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }
            var teacher = await _context.Teacher.FindAsync(id);

            if (teacher != null)
            {
                Teachers = teacher;
                _context.Teacher.Remove(Teachers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

