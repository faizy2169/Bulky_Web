using BulkeyWeb.Data;
using BulkeyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkeyWeb.Controllers
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
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            // Server Side Validation

            if (obj.Name != null && obj.Name.ToLower() == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The field value should not be same.");
            }
            if (obj.Name == "test")
            {
                ModelState.AddModelError("", "Test value is not allowed");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFrmDb = _db.Categories.Find(id);
            //Category? categoryFrmDb1 = _db.Categories.FirstOrDefault(item => item.Id == id);
            //Category? categoryFrmDb2 = _db.Categories.Where(item => item.Id == id).FirstOrDefault();
            if (categoryFrmDb == null)
            {
                return NotFound();
            }
            return View(categoryFrmDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

    }
}
