using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tarefa1.Models
{
    public class UtilizadorPadrao : IdentityUser
    {
        [Required]
        public string Nome { get; set; } // Nome do utilizador
        public string Morada { get; set; } // Morada do utilizador
    }
}
