using Microsoft.AspNetCore.Mvc;
using Tarefa1.Data;
using Tarefa1.Models;

namespace Tarefa1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public ClientesController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var clientes = _dbContext.Clientes.ToList();
            return View(clientes);
        }
    }
}
