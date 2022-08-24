using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    public class ManutencaoVeiculoController : Controller
    {
        // GET: ManutencaoVeiculoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManutencaoVeiculoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManutencaoVeiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManutencaoVeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManutencaoVeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManutencaoVeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManutencaoVeiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManutencaoVeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
