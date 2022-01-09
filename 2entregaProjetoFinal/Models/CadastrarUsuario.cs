using System;
using System.ComponentModel.DataAnnotations;

namespace _2entregaProjetoFinal.Models
{
    public class CadastrarUsuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Nome_Social { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Confirme_Senha { get; set; }
    }
}
