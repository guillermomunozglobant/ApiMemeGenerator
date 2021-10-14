using ApiMemeGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMemeGenerator.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions) :
          base(dbContextOptions)
        {

        }
        internal DbSet<Imagen> Imagen { get; set; }
        internal DbSet<Usuario> Usuario { get; set; }
    }
}
