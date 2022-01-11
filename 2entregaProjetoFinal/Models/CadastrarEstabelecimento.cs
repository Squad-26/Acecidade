using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2entregaProjetoFinal.Models
{
    public class CadastrarEstabelecimento
    {
        [Key]
        public int IdEstabelecimento { get; set; }
        public string NomeEstabelecimento { get; set; }
        public float NotaEstabelecimento { get; set; }
        [DataType(DataType.Time)]
        public string HorarioFuncionamento { get; set; }
        public string ComentariosEstabelecimento{ get; set; }
        public string AcessibilidadesEstabelecimentos { get; set; }
        public virtual List<Avaliacao> Avaliacao { get; set; }
    }
}
