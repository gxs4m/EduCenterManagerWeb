using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EduCenterManagerWeb.Pages.Student
{
    public class EditModel : PageModel
    {
        public readonly EduCenterManagerContext _context;
        public EditModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Students Students { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var students = await _context.Student.FirstOrDefaultAsync(m => m.IdEstudiante == id);
            
            if (students == null)
            {
                return NotFound();
            }
            Students = students;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Students).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(Students.IdEstudiante))
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
        private bool StudentsExists(int id)
        {
            return (_context.Student?.Any(e => e.IdEstudiante == id)).GetValueOrDefault();
        }
    }
}
