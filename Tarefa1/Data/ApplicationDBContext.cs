using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefa1.Models;

namespace Tarefa1.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; } // Produto é o nome da classe. Produtos é o nome do DbSet

        public DbSet<Cliente> Clientes { get; set; } // Cliente é o nome da classe. Clientes é o nome do DbSet

        public DbSet<UtilizadorPadrao> Utilizadores { get; set; } // UtilizadorPadrao é o nome da classe. Utilizadores é o nome do DbSet
    }
}
