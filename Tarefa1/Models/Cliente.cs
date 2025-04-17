using System.ComponentModel.DataAnnotations;

namespace Tarefa1.Models
{
    public class Cliente
    {
        [Key] // Assim garanto que o Id é a chave primária
        public int Id { get; set; } // ID (Automático)

        [Required(ErrorMessage = "Obrigatório colocar o nome!")] // Valida se o nome é obrigatório
        public string? Nome { get; set; } // Nome do cliente

        [Required(ErrorMessage = "Obrigatório colocar o email!")] // Valida se o email é obrigatório
        [EmailAddress(ErrorMessage = "Email inválido!")] // Valida se o email é válido
        public string? Email { get; set; } // Email do cliente

        [Required(ErrorMessage = "Obrigatório colocar o telefone!")] // Valida se o telefone é obrigatório
        [RegularExpression(@"^\d*$", ErrorMessage = "O telefone deve conter apenas números.")] // Valida se o telefone contém apenas números
        public string? Telefone { get; set; } // Telefone do cliente
    }
}
