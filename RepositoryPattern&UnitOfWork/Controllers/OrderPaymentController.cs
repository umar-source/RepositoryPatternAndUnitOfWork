using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
    public class OrderPaymentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderPaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var orderPayment = _unitOfWork.OrderPaymentRepo.GetAll();
            return View(orderPayment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderPayment orderPayment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.OrderPaymentRepo.Add(orderPayment);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(orderPayment);
        }

        public IActionResult Delete(int id)
        {
            var orderPayment = _unitOfWork.OrderPaymentRepo.GetById(id);
            if (orderPayment == null)
            {
                return NotFound();
            }
            return View(orderPayment);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var orderPayment = _unitOfWork.OrderPaymentRepo.GetById(id);
            _unitOfWork.OrderPaymentRepo.Delete(orderPayment);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var orderPayment = _unitOfWork.OrderPaymentRepo.GetById(id);
            if (orderPayment == null)
            {
                return NotFound();
            }
            return View(orderPayment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderPayment orderPayment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.OrderPaymentRepo.Update(orderPayment);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(orderPayment);
        }
    }
}
