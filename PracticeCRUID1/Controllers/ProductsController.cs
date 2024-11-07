using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeCRUID1.Models;

namespace PracticeCRUID1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            return View(ProductRepository.Products);
        }

        // register Search function here
        [HttpPost]
        public ActionResult Search(string keywords)
        {
            return View("Index", ProductRepository.Products.Where(p=>p.Name.Contains(keywords)));
        }
        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View(ProductRepository.product(id));
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                // Kiểm tra điều kiện kích hoạt validation
                if (ModelState.IsValid)
                {
                    ProductRepository.Addnew(product);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = ProductRepository.product(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                ProductRepository.Edit(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = ProductRepository.product(id);

            ProductRepository.RemoveProduct(product);
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductsController/Delete/5
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
