using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EduCenterManagerWeb.Pages.Student
{
    public class DeleteModel : PageModel
    {
         private readonly EduCenterManagerContext _context;  

        public DeleteModel(EduCenterManagerContext context)
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
            else
            {
                Students = students;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var students = await _context.Student.FindAsync(id);
            
            if (students != null)
            {
                Students = students;
                _context.Student.Remove(Students);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
