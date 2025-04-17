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

        public IActionResult AdicionarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarCliente(Cliente clienteInserido)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Clientes.Add(clienteInserido);
                _dbContext.SaveChanges();
                    TempData["Mensagem"] = "Cliente adicionado com sucesso!";
                    TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }
            return View(clienteInserido);
        }

        public IActionResult EditarCliente(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var clienteBd = _dbContext.Clientes.Find(id);
            if (clienteBd == null)
                return NotFound();

            return View(clienteBd);
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente clienteInserido)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Clientes.Update(clienteInserido);
                _dbContext.SaveChanges();
                    TempData["Mensagem"] = "Cliente editado com sucesso!";
                    TempData["Tipo"] = "warning";
                return RedirectToAction("Index");
            }
            return View(clienteInserido);
        }

        public IActionResult ApagarCliente(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var clienteBd = _dbContext.Clientes.Find(id);
            if (clienteBd == null)
                return NotFound();

            return View(clienteBd);
        }

        [HttpPost]
        public IActionResult ApagarCliente(Cliente clienteInserido)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Clientes.Remove(clienteInserido);
                _dbContext.SaveChanges();
                    TempData["Mensagem"] = "Cliente apagado com sucesso!";
                    TempData["Tipo"] = "error";
                return RedirectToAction("Index");
            }
            return View(clienteInserido);
        }
    }
}
