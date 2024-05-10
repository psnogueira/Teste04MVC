using System.ComponentModel.DataAnnotations;
using Teste04.Models;

namespace Teste04.Models
{
    public class ListaDeTarefas
    {
        [Key]
        public int ListaDeTarefasID { get; set; }

        [Required(ErrorMessage = "O Nome da Lista é obrigatório.")]
        [Display(Name = "Nome da Lista de Tarefas")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição da Lista")]
        public string Desc { get; set; } = string.Empty;

        [Display(Name = "Data de Início")]
        [Required(ErrorMessage = "A data de início da tarefa é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DtInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DtFim { get; set; }

        public List<Tarefa> Tarefas { get; set; }

        public bool Status { get; set; }
    }
}
