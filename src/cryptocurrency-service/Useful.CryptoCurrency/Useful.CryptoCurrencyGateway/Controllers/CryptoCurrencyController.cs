using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Useful.CryptoCurrencyGateway.Controllers
{
    public class CryptoCurrencyController : Controller
    {
        // GET: CryptoCurrencyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CryptoCurrencyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CryptoCurrencyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CryptoCurrencyController/Create
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

        // GET: CryptoCurrencyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CryptoCurrencyController/Edit/5
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

        // GET: CryptoCurrencyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CryptoCurrencyController/Delete/5
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
