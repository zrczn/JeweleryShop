using Jewelery.DataAccess.Repository.IRepository;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jewelery.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WearingTypeController : Controller
    {
        private readonly IUnitOfWork _repo;

        public WearingTypeController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            IEnumerable<WearingType> getAll = _repo.WearingTypeRepository.GetAll();

            return View(getAll);
        }

        public IActionResult Create()
        {
            return View(new WearingType());
        }

        [HttpPost]
        public IActionResult Create(WearingType obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.WearingTypeRepository.Add(obj);
            _repo.Save();

            TempData["Action"] = "Record has been added";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            WearingType getObj = _repo.WearingTypeRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Edit(WearingType obj)
        {
            _repo.WearingTypeRepository.Update(obj);
            _repo.Save();

            TempData["Action"] = "Record has been edited";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? Id)
        {
            WearingType getObj = _repo.WearingTypeRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Delete(WearingType obj)
        {
            _repo.WearingTypeRepository.Remove(obj);
            _repo.Save();

            TempData["Action"] = "Record has been deleted";

            return RedirectToAction("Index");
        }
    }
}
