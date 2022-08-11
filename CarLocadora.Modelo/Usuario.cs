using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo
{
    public class Usuario : Endereco
    {
        [Key]
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        [StringLength(50, ErrorMessage = "Este campo deve ter 50 caracteres")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter de 5 a 150 caractéres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }


        [StringLength(15, ErrorMessage = "Este campo deve ter no maximo 15 caracteres")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [StringLength(15, ErrorMessage = "Este campo deve ter no maximo 15 caracteres")]
        public string Celular { get; set; }

        [StringLength(300, ErrorMessage = "Este campo deve ter no maximo 300 caracteres")]
        public string? Senha { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Data Inclusão")]
        public DateTime? DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
