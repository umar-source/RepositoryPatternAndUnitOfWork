using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var productCategory = _unitOfWork.ProductCategoryRepo.GetAll();
            return View(productCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductCategoryRepo.Add(productCategory);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }

        public IActionResult Delete(int id)
        {
            var productCategory = _unitOfWork.ProductCategoryRepo.GetById(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var productCategory = _unitOfWork.ProductCategoryRepo.GetById(id);
            _unitOfWork.ProductCategoryRepo.Delete(productCategory);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var productCategory = _unitOfWork.ProductCategoryRepo.GetById(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductCategoryRepo.Update(productCategory);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }
    }
}
