using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;

namespace EduCenterManagerWeb.Pages.Rating
{
    public class EditModel : PageModel
    {

        private readonly EduCenterManagerContext _context;

        public EditModel(EduCenterManagerContext context)
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
            var ratings = await _context.Rating.FirstOrDefaultAsync(m => m.Id == id);
            if (ratings == null)
            {
                return NotFound();
            }
            Ratings = ratings;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ratings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingsExists(Ratings.Id))
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

        private bool RatingsExists(int? id)
        {
            return (_context.Rating?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
