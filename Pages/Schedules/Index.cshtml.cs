using EduCenterManagerWeb.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly EduCenterManagerContext _context;

        public IndexModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        public IList<Models.Schedules> ScheduleList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Incluye los datos del curso relacionado
            ScheduleList = await _context.Schedule
                                         .Include(s => s.Courses)
                                         .ToListAsync();
        }
    }
}
