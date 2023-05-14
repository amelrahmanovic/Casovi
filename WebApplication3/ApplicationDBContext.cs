using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace WebApplication3
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> context) : base(context)
        {

        }

        public DbSet<Osoba> Osoba { get; set; }
    }
}
