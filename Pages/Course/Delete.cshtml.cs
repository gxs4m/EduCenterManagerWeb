using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Course
{
    public class DeleteModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public DeleteModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Courses Courses { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var courses = await _context.Course
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (courses == null)
            {
                return NotFound();
            }
            Courses = courses;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }
            var courses = await _context.Course.FindAsync(id);

            if (courses != null)
            {
                Courses = courses;
                _context.Course.Remove(Courses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}