using System.ComponentModel.DataAnnotations;

namespace Teste04.Models
{
    public class Tarefa
    {
        [Key]
        public int TarefaID { get; set; }

        [Required(ErrorMessage = "O Nome da Tarefa é obrigatório.")]
        [Display(Name = "Nome da Tarefa")]
        [StringLength(100, ErrorMessage = "O nome da tarefa não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição da Tarefa")]
        [StringLength(511, ErrorMessage = "A descrição do produto não pode ter mais que 511 caracteres.")]
        public string Desc { get; set; } = string.Empty;

        [Display(Name = "Data de Início")]
        [Required(ErrorMessage = "A data de início da tarefa é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DtInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DtFim { get; set; }

        public bool Status { get; set; }
    }
}
