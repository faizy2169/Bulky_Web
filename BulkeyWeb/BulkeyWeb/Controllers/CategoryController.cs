using BulkeyWeb.Data;
using BulkeyWeb.Models;
using BulkeyWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkeyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IGlobalRepository _globalRepo;
        public CategoryController(IGlobalRepository globalRepo)
        {
            _globalRepo = globalRepo;
        }
        public IActionResult Index()
        {
            //List<Category> categories = _db.Categories.ToList();
            //List<Category> categories = _categoryRepo.GetAll().ToList(); 
            List<Category> categories = _globalRepo.categoryRepo.GetAll().ToList();


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
                //_db.Categories.Add(obj);
                //_db.SaveChanges();

                //_categoryRepo.Add(obj);
                //_categoryRepo.Save();

                _globalRepo.categoryRepo.Add(obj);
                _globalRepo.Save();
                TempData["success"] = "Data Created Successfully";
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
            //Category? categoryFrmDb = _db.Categories.Find(id);

            //Category? categoryFrmDb = _categoryRepo.Find(item => item.Id == id);
            Category? categoryFrmDb = _globalRepo.categoryRepo.Find(item => item.Id == id);


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
                //_categoryRepo.Update(obj);
                //_categoryRepo.Save();
                _globalRepo.Update(obj);
                _globalRepo.Save();
                TempData["success"] = "Data Updated Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryDel = _categoryRepo.Find(item => item.Id == id);
            Category? categoryDel = _globalRepo.categoryRepo.Find(item => item.Id == id);

            if (categoryDel == null)
            {
                return NotFound();
            }
            return View(categoryDel);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //Category? obj = _categoryRepo.Find(item => item.Id == id);
            Category? obj = _globalRepo.categoryRepo.Find(item => item.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _globalRepo.categoryRepo.Remove(obj);
            _globalRepo.Save();
            TempData["success"] = "Data Deleted Successfully";

            return RedirectToAction("Index", "Category");
        }

    }
}
