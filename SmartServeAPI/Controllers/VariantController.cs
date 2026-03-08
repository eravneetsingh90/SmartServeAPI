using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartServe.API.Controllers
{
    public class VariantController : Controller
    {
        // GET: VariantController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VariantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VariantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VariantController/Create
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

        // GET: VariantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VariantController/Edit/5
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

        // GET: VariantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VariantController/Delete/5
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
