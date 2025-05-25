using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduCenterManagerWeb.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly EduCenterManagerContext _context;
        public IndexModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        public IList<Models.Courses> Courses { get; set; } = default!;
        public async Task OnGet()
        {
            if (_context.Course != null)
            {
                Courses = await _context.Course
                    .Include(c => c.Teachers) 
                    .ToListAsync();
            }
        }
    }
}
