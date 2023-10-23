using ApiProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProductos.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options
            ): base(options) { }

        DbSet<Producto> Producto { get; set; }

    }
}
