using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using waInventario.DAO.Item;
using waInventario.Models.Item.Input;
using waInventario.Models.Item.Query;

namespace waInventario.Controllers
{
    public class ItemController : Controller
    {
        private ItemDAO itemDao = new ItemDAO();

        public ActionResult Index()
        {
            return View(itemDao.RetornarTodos());
        }

        public ActionResult Buscar(){ 
            
            string pesquisa = HttpContext.Request.Form["pesquisa"];
            return View("Index", itemDao.RetornarPorNome(pesquisa));
        }

        public ActionResult Details(int id)
        {
            RetornarPorId item = itemDao.RetornarPorId(id);
            return View(item);
        }

        public ActionResult Create()
        {
            ItemAdicionarViewModel item = new ItemAdicionarViewModel();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ItemAdicionarViewModel item = new ItemAdicionarViewModel();
                TryUpdateModelAsync(item);
                itemDao.Inserir(item);
                TempData["success"] = "Item adicionado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["error"] = "Erro ao adicionar novo item";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {

            RetornarPorId item = itemDao.RetornarPorId(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ItemAtualizarViewModel item = new ItemAtualizarViewModel();
                TryUpdateModelAsync(item);
                itemDao.Alterar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Delete(int id)
        {
            RetornarPorId item = itemDao.RetornarPorId(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ItemDeletarViewModel item = new ItemDeletarViewModel();
                TryUpdateModelAsync(item);
                itemDao.Deletar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}