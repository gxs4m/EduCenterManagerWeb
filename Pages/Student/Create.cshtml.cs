using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EduCenterManagerWeb.Models;


namespace EduCenterManagerWeb.Pages.Student
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
        public Students Students { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Student == null || Students == null)
            {
                return Page();
            }
            _context.Student.Add(Students);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    
} 


