using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo
{
    public class FormaPagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Este campo deve ter de 10 a 150 caractéres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
