using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using waInventario.DAO.Local;
using waInventario.Models.Local.Input;

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

        // GET: Local/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Local/Create
        public ActionResult Create()
        {
            return View();
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
            return View();
        }

        // POST: Local/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Local/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Local/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}