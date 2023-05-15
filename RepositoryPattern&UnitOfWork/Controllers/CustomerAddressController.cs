using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
    public class CustomerAddressController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerAddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var customerAddress = _unitOfWork.CustomerAddressRepo.GetAll();
            return View(customerAddress);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CustomerAddressRepo.Add(customerAddress);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(customerAddress);
        }

        public IActionResult Delete(int id)
        {
            var customerAddress = _unitOfWork.CustomerAddressRepo.GetById(id);
            if (customerAddress == null)
            {
                return NotFound();
            }
            return View(customerAddress);
        }





        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var customer = _unitOfWork.CustomerAddressRepo.GetById(id);
            _unitOfWork.CustomerAddressRepo.Delete(customer);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var customerAddress = _unitOfWork.CustomerAddressRepo.GetById(id);
            if (customerAddress == null)
            {
                return NotFound();
            }
            return View(customerAddress);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CustomerAddressRepo.Update(customerAddress);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(customerAddress);
        }
    }
}
