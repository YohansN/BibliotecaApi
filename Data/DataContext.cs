using Biblioteca.Models;

namespace Biblioteca.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BibliotecaData> BibliotecaDatas { get; set; }
    }
}