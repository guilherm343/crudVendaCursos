using Microsoft.EntityFrameworkCore;
using TCCTrabalho.Models;

namespace TCCTrabalho.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        } 

        public DbSet<CursoModel> Cursos { get; set; }
    }
}
