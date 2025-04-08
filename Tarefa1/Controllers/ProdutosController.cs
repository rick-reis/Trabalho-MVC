using Microsoft.AspNetCore.Mvc;
using Tarefa1.Data;
using Tarefa1.Models;

namespace Tarefa1.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public ProdutosController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Produto> listaProdutos = _dbContext.Produtos.ToList();
            return View(listaProdutos);
        }
    }
}
