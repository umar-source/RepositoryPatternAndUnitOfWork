/* 
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_UnitOfWork.Services;

namespace RepositoryPattern_UnitOfWork.Controllers
{
public abstract class BaseController<T> : Controller where T : class
  {
      protected readonly IUnitOfWork _unitOfWork;

      protected BaseController(IUnitOfWork unitOfWork)
      {
          _unitOfWork = unitOfWork;
      }

      public virtual IActionResult Index()
      {
          var entities = _unitOfWork.GetRepository<T>().GetAll();
          return View(entities);
      }

      public virtual IActionResult Create()
      {
          return View();
      }

      [HttpPost]
      public virtual IActionResult Create(T entity)
      {
          if (ModelState.IsValid)
          {
              _unitOfWork.GetRepository<T>().Add(entity);
              _unitOfWork.Commit();
              return RedirectToAction(nameof(Index));
          }
          return View(entity);
      }

      public virtual IActionResult Delete(int id)
      {
          var entity = _unitOfWork.GetRepository<T>().GetById(id);
          if (entity == null)
          {
              return NotFound();
          }
          return View(entity);
      }

      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public virtual IActionResult ConfirmDelete(int id)
      {
          var entity = _unitOfWork.GetRepository<T>().GetById(id);
          _unitOfWork.GetRepository<T>().Delete(entity);
          _unitOfWork.Commit();
          return RedirectToAction(nameof(Index));
      }

      public virtual IActionResult Edit(int id)
      {
          var entity = _unitOfWork.GetRepository<T>().GetById(id);
          if (entity == null)
          {
              return NotFound();
          }
          return View(entity);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public virtual IActionResult Edit(T entity)
      {
          if (ModelState.IsValid)
          {
              _unitOfWork.GetRepository<T>().Update(entity);
              _unitOfWork.Commit();
              return RedirectToAction(nameof(Index));
          }
          return View(entity);
      }
  }

}
*/