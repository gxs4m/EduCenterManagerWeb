using EduCenterManagerWeb.Data;
using EduCenterManagerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduCenterManagerWeb.Pages.Rating
{
    public class IndexModel : PageModel
    {
        private readonly EduCenterManagerContext _context;


        public IndexModel(EduCenterManagerContext context)
        {
            _context = context;
        }

        public List<Ratings> Rating { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Rating != null)
            {
                Rating = await _context.Rating.ToListAsync();
            }

        }
    }
}