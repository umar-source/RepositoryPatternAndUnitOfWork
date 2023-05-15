using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var order = _unitOfWork.OrderRepo.GetAll();
            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.OrderRepo.Add(order);
                    _unitOfWork.Commit();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    var sqlException = ex.InnerException as SqlException;
                    //   Number property of the SqlException is equal to 547,
                    //   which indicates a foreign key constraint violation
                    if (sqlException != null && sqlException.Number == 547)
                    {
                        // adding a model-level error to the ModelState using the AddModelError
                        ModelState.AddModelError(string.Empty, "The selected customer id is invalid.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _unitOfWork.OrderRepo.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var order = _unitOfWork.OrderRepo.GetById(id);
            _unitOfWork.OrderRepo.Delete(order);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            var order = _unitOfWork.OrderRepo.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.OrderRepo.Update(order);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
    }
}
