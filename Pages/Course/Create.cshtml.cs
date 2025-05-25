using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Course
{
    public class CreateModel : PageModel
    {
        private readonly EduCenterManagerContext _context;
        public CreateModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Models.Courses Course { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Course == null || Course == null)
            {
                return Page();
            }
            _context.Course.Add(Course);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

