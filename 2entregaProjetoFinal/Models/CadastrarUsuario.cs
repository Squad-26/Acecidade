using System;
using System.ComponentModel.DataAnnotations;

namespace _2entregaProjetoFinal.Models
{
    public class CadastrarUsuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string NessecidadeEspecial { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        public DateTime Data_Nascimento { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
