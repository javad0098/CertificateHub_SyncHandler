using Microsoft.EntityFrameworkCore;
using SkillService.Models;

namespace SkillService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Skill> Skills { get; set; }
    }
}
