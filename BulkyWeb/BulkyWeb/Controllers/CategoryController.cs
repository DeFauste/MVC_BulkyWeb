using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Categoty> objCategoryList = _db.Categoties.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoty obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly mathc the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categoties.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
                return NotFound();
            }
            Categoty categotyFromDb = _db.Categoties.Find(id);
            if (categotyFromDb == null)
            {
                return NotFound();
            }
            return View(categotyFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Categoty obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly mathc the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categoties.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categoty categotyFromDb = _db.Categoties.Find(id);
            if (categotyFromDb == null)
            {
                return NotFound();
            }
            return View(categotyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Categoty? obj = _db.Categoties.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categoties.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category success delete";
            return RedirectToAction("Index");
        }
    }
}
