using Microsoft.EntityFrameworkCore;
using CertificateService.Models;

namespace CertificateService.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>  opt): base(opt)
        {

        }
        public DbSet<Certificate> Certificates { get; set; }
    }
}