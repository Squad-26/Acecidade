using Microsoft.EntityFrameworkCore;

namespace _2entregaProjetoFinal.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CadastrarUsuario> usuarios { get; set; }
        public DbSet<CadastrarEstabelecimento> estabelecimentos { get; set; }
        public DbSet<Avaliacao> avaliacoes  { get; set; }
    }
}
