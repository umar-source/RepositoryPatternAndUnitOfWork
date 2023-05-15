using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var customers = _unitOfWork.CustomerRepo.GetAll();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CustomerRepo.Add(customer);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _unitOfWork.CustomerRepo.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }





        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var customer = _unitOfWork.CustomerRepo.GetById(id);
            _unitOfWork.CustomerRepo.Delete(customer);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var customer = _unitOfWork.CustomerRepo.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CustomerRepo.Update(customer);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
