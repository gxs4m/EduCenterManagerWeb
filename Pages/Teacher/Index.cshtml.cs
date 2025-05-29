using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Teacher
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly EduCenterManagerContext _context;
        
        public IndexModel(EduCenterManagerContext context)
        {
            _context = context;
        }
        public IList<Teachers> Teacher { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Teacher != null)
            {
                Teacher = await _context.Teacher.ToListAsync();
            }
        }
    }
}
