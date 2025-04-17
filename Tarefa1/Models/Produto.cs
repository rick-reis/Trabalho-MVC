using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefa1.Models
{
    public class Produto
    {
        [Key] // Assim garanto que o Id é a chave primária
        public int Id { get; set; } // ID (Automático)

        [Required(ErrorMessage ="O campo deve ser preenchido!")] // Valida se o nome é obrigatório
        public string Nome { get; set; } // Nome do produto

        [Required(ErrorMessage = "O campo deve ser preenchido!")] // Valida se o Preço é obrigatório
        [DisplayName("Preço")] // Exibe o nome do campo como "Preço"
        public float Preco { get; set; } // Preço do produto
    }
}
