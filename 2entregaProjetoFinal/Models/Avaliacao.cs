using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2entregaProjetoFinal.Models
{
    public class Avaliacao
    {
        [Key]
        public int IdAvaliacao { get; set; }
        [ForeignKey("CadastrarUsuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("CadastrarEstabelecimento")]
        public int IdEstabelecimento { get; set; }
        public float NotaEstabelecimento { get; set; }
        public string Comentario { get; set; }
        public virtual CadastrarEstabelecimento CadastrarEstabelecimento { get; set; }
        public virtual CadastrarUsuario CadastrarUsuario { get; set; }
    }
}
