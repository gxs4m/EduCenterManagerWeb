using EduCenterManagerWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EduCenterManagerWeb.Data
{
    public class EduCenterManagerContext : DbContext
    {
        public EduCenterManagerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Courses> Course { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<Teachers> Teacher { get; set; }
        public DbSet<Schedules> Schedule { get; set; }
        public DbSet<Ratings> Rating { get; set; }

    }
}
