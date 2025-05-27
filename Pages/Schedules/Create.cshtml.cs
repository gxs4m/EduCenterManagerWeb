using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Schedules
{
    public class CreateModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public CreateModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Schedules Schedule { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["Course"] = new SelectList(_context.Course, "Id", "NombreCurso");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Schedule == null)
            {
                ViewData["Courses"] = new SelectList(_context.Course, "IdCurso", "Nombre");
                return Page();
            }

            _context.Schedule.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}