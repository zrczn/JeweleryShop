using Jewelery.DataAccess.Repository.IRepository;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialController : Controller
    {
        private readonly IUnitOfWork _repo;

        public MaterialController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            IEnumerable<Material> getAll = _repo.MaterialRepository.GetAll();

            return View(getAll);
        }

        public IActionResult Create()
        {
            return View(new Material());
        }

        [HttpPost]
        public IActionResult Create(Material obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.MaterialRepository.Add(obj);
            _repo.Save();

            TempData["Action"] = "Record has been added";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            Material getObj = _repo.MaterialRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Edit(Material obj)
        {
            _repo.MaterialRepository.Update(obj);
            _repo.Save();

            TempData["Action"] = "Record has been edited";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? Id)
        {
            Material getObj = _repo.MaterialRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Delete(Material obj)
        {
            _repo.MaterialRepository.Remove(obj);
            _repo.Save();

            TempData["Action"] = "Record has been deleted";

            return RedirectToAction("Index");
        }
    }
}
