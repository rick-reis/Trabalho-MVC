using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult AdicionarProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarProduto(Produto produtoRecebido)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Produtos.Add(produtoRecebido);
                _dbContext.SaveChanges();
                    TempData["Mensagem"] = "Produto adicionado com sucesso!";
                    TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }
            return View(produtoRecebido);

        }

        public IActionResult EditarProduto(int? id)
        {
            if (id == null || id == 0) // Verifica se o id é null ou 0
                return NotFound();

            var produtodaBd = _dbContext.Produtos.Find(id); // Verifica se o produto existe
            if (produtodaBd == null)
                return NotFound();
            
            return View(produtodaBd); // Se o produto existe, retorna a view com o produto
        }

        [HttpPost]
        public IActionResult EditarProduto(Produto produtoRecebido)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Produtos.Update(produtoRecebido);
                _dbContext.SaveChanges();
                    TempData["Mensagem"] = "Produto editado com sucesso!";
                    TempData["Tipo"] = "warning";
                return RedirectToAction("Index");
            }
            return View(produtoRecebido);

        }

        public IActionResult ApagarProduto(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var produtodaBd = _dbContext.Produtos.Find(id);
            if (produtodaBd == null)
                return NotFound();

            return View(produtodaBd);
        }

        [HttpPost]
        public IActionResult ApagarProduto(Produto produtoRecebido)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Produtos.Remove(produtoRecebido);
                _dbContext.SaveChanges();
                    TempData["Mensagem"] = "Produto apagado com sucesso!";
                    TempData["Tipo"] = "error";
                return RedirectToAction("Index");
            }
            return View(produtoRecebido);

        }
    }
}
