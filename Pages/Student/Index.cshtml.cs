using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace EduCenterManagerWeb.Pages.Student
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public IndexModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        public IList<Students> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }
    }
}