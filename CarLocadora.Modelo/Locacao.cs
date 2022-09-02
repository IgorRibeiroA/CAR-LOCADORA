using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo
{
    public class Locacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 caracteres")]
        [Display(Name = "CPF do Clinte")]
        public string ClienteCPF { get; set; }
        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "O campo Forma Pagamento é obrigatório.")]
        public int FormaPagamentoId { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }

        //[Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        //public int CategoriaId { get; set; }
        //public Categoria? Categoria { get; set; }


        [Required(ErrorMessage = "O campo Data da reserva é obrigatório.")]
        [Display(Name = " Data da reserva")]
        public DateTime DataHoraReserva { get; set; }

        [Required(ErrorMessage = "O campo Data da retirada é obrigatório.")]
        [Display(Name = " Data da retirada")]
        public DateTime DataHoraRetiradaPrevista { get; set; }

        [Required(ErrorMessage = "O campo Data da devolução é obrigatório.")]
        [Display(Name = " Data da devolução")]
        public DateTime DataHoraDevolucaoPrevista { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Este campo deve ter 8 caracteres")]
        public string VeiculoPlaca { get; set; }
        public Veiculo? Veiculo { get; set; }

        [Display(Name = "Data Inclusão")]
        public DateTime? DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
