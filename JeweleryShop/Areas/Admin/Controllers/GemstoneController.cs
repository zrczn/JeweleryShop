using Jewelery.DataAccess.Repository.IRepository;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GemstoneController : Controller
    {
        private readonly IUnitOfWork _repo;

        public GemstoneController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            IEnumerable<Stone> getAll = _repo.GemstoneRepository.GetAll();

            return View(getAll);
        }

        public IActionResult Create()
        {
            return View(new Stone());
        }

        [HttpPost]
        public IActionResult Create(Stone obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.GemstoneRepository.Add(obj);
            _repo.Save();

            TempData["Action"] = "Record has been added";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            Stone getObj = _repo.GemstoneRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Edit(Stone obj)
        {
            _repo.GemstoneRepository.Update(obj);
            _repo.Save();

            TempData["Action"] = "Record has been edited";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? Id)
        {
            Stone getObj = _repo.GemstoneRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Delete(Stone obj)
        {
            _repo.GemstoneRepository.Remove(obj);
            _repo.Save();

            TempData["Action"] = "Record has been deleted";

            return RedirectToAction("Index");
        }
    }
}
