using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var product = _unitOfWork.ProductRepo.GetAll();
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepo.Add(product);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        

        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            _unitOfWork.ProductRepo.Delete(product);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepo.Update(product);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
