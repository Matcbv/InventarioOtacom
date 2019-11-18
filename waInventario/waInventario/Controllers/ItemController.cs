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

        // GET: Item
        public ActionResult Index()
        {
            return View(itemDao.RetornarTodos());
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {

            ItemViewModel item = new ItemViewModel();
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ItemAdicionarViewModel item = new ItemAdicionarViewModel();
            return View(item);
        }

        // POST: Item/Create
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

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            ItemAtualizarViewModel item = new ItemAtualizarViewModel();
            return View(item);
        }

        // POST: Item/Edit/5
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
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            ItemViewModel item = itemDao.RetornarPorId(id);
            return View(item);
        }

        // POST: Item/Delete/5
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