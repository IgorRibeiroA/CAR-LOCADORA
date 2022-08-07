using System.ComponentModel.DataAnnotations;


namespace CarLocadora.Modelo
{
    public class Veiculo
    {
        [Key]
        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Este campo deve ter 8 caracteres")]
        public string Placa { get; set; }

        [StringLength(100, ErrorMessage = "Este campo deve ter no máximo 100 caracteres")]
        public string?  Chassi { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Este campo deve ter no máximo 100 e no minimo 10 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Este campo deve ter no máximo 150 e no minimo 10 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Combustivel é obrigatório.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Este campo deve ter no máximo 100 e no minimo 6 caracteres")]
        public string Combustivel { get; set; }

        [Required(ErrorMessage = "O campo Combustivel é obrigatório.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Este campo deve ter no máximo 100 e no minimo 6 caracteres")]
        public string Cor { get; set; }

        [StringLength(2000, ErrorMessage = "Este campo deve ter no máximo 2000 caracteres")]
        public string? Opcionais { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }

}
