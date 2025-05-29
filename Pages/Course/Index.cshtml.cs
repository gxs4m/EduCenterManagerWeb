using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduCenterManagerWeb.Pages.Course
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EduCenterManagerContext _context;
        public IndexModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        public IList<Courses> course { get; set; } = default!;
        
        public async Task OnGetAsync()
        {
            if (_context.Course != null)
            {
                course = await _context.Course.ToListAsync();
            }
        }
    }
}
