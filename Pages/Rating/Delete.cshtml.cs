using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;

namespace EduCenterManagerWeb.Pages.Rating
{
    public class DeleteModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public DeleteModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Ratings Ratings { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }
            var ratings = await _context.Rating.FirstOrDefaultAsync(m => m.IdCalificacion == id);

            if (ratings == null)
            {
                return NotFound();
            }
            else
            {
                Ratings = ratings;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }
            var ratings = await _context.Rating.FindAsync(id);

            if (ratings != null)
            {
                Ratings = ratings;
                _context.Rating.Remove(Ratings);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
