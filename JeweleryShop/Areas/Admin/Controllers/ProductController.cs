using JeweleryShop.DatabaseContext;
using Jewelery.Models;
using Microsoft.AspNetCore.Mvc;
using Jewelery.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Jewelery.Models.VM;

namespace Jewelery.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _repo;

        public ProductController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> getAll = _repo.ProductRepository.GetAll();

            return View(getAll);
        }

        //update - insert
        public IActionResult Create()
        {

            ProductVM ProductViewModel = new ProductVM {
                Product = new Product(),
                SelectMaterials = _repo.MaterialRepository.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Type
                }),
                SelectStones = _repo.GemstoneRepository.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Type
                }),
                SelectWearingTypes = _repo.WearingTypeRepository.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Type
                })
        };

            return View(ProductViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductVM obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.ProductRepository.Add(obj.Product);
            _repo.Save();

            TempData["Action"] = "Record has been added";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            Product getObj = _repo.ProductRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            _repo.ProductRepository.Update(obj);
            _repo.Save();

            TempData["Action"] = "Record has been edited";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? Id)
        {
            Product getObj = _repo.ProductRepository.GetSingle(x => x.Id == Id);

            if (getObj == null)
                NotFound();

            return View(getObj);
        }

        [HttpPost]
        public IActionResult Delete(Product obj)
        {
            _repo.ProductRepository.Remove(obj);
            _repo.Save();

            TempData["Action"] = "Record has been deleted";

            return RedirectToAction("Index");
        }
    }
}
