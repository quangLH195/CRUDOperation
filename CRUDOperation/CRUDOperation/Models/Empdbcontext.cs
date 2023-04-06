using Microsoft.EntityFrameworkCore;
namespace CRUDOperation.Models
{
    public class Empdbcontext : DbContext
    {
        public Empdbcontext(DbContextOptions<Empdbcontext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}
