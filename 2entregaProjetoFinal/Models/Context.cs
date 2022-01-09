using Microsoft.EntityFrameworkCore;

namespace _2entregaProjetoFinal.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CadastrarUsuario> usuarios { get; set; }
    }
}
