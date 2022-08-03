using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo
{
    internal class Endereco
    {
        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Este campo deve ter no maximo 50 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Este campo deve ter no maximo 50 caracteres")]
        public string Numero { get; set; }

        [StringLength(50, ErrorMessage = "Este campo deve conter no maximo 50 caractéres")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Este campo deve ter no maximo 50 caracteres")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "Este campo deve conter apenas as 2 siglas de estado")]
        public string Estado { get; set; }
    }
}
