using Microsoft.EntityFrameworkCore;

namespace Prueba.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> TblProductos { get; set; }
        public DbSet<Categoria> TblCategorias { get; set; }
        public DbSet<Usuario> TblUsuarios { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDatos;Integrated Security=True;");
        }
    }
}
