using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using waInventario.DAO.Local;
using waInventario.Models.Local.Input;
using waInventario.Models.Local.Query;

namespace waInventario.Controllers
{
    public class LocalController : Controller
    {
        private LocalDAO localDao = new LocalDAO();

        // GET: Local
        public ActionResult Index()
        {
            return View(localDao.RetornarTodos());
        }

        public ActionResult Buscar()
        {
            string pesquisa = HttpContext.Request.Form["pesquisa"];
            return View("Index", localDao.RetornarPorDescricao(pesquisa));
        }

        // GET: Local/Details/5
        public ActionResult Details(int id)
        {
            LocalViewModel local = localDao.RetornarPeloId(id);
            return View(local);
        }

        // GET: Local/Create
        public ActionResult Create()
        {
            LocalAdicionarViewModel local = new LocalAdicionarViewModel();
            return View(local);
        }

        // POST: Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                LocalAdicionarViewModel local = new LocalAdicionarViewModel();
                TryUpdateModelAsync(local);
                localDao.Inserir(local);
                TempData["success"] = "Local adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["error"] = "Erro ao adicionar novo local...";
                return RedirectToAction("Index");
            }
        }

        // GET: Local/Edit/5
        public ActionResult Edit(int id)
        {
            LocalViewModel local = localDao.RetornarPeloId(id);
            return View(local);
        }

        // POST: Local/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                LocalAtualizarViewModel local = new LocalAtualizarViewModel();
                TryUpdateModelAsync(local);
                localDao.Alterar(local);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Local/Delete/5
        public ActionResult Delete(int id)
        {
            LocalViewModel local = localDao.RetornarPeloId(id);
            return View(local);
        }

        // POST: Local/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                LocalDeletarViewModel local = new LocalDeletarViewModel();
                TryUpdateModelAsync(local);
                localDao.Deletar(local);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}