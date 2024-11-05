
using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> catlist = _categoryRepo.GetAll().ToList();
            return View(catlist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["Success"] = "Category Created Successifully";
                return RedirectToAction("Index");
            }
            return  View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            Category? catdata = _categoryRepo.Get(u=>u.Id==id);
            if (catdata == null)
            {
                return NotFound();
            }
            
            return View(catdata);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(category);
                _categoryRepo.Save();
                TempData["Success"] = "Category Updated Successifully";
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
            Category? catdata = _categoryRepo.Get(u => u.Id == id);
            if (catdata == null)
            {
                return NotFound();
            }

            return View(catdata);
        }
        [HttpPost, ActionName("Delete")]
        
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
                var getid = _categoryRepo.Get(u => u.Id == id);
                 _categoryRepo.Remove(getid);
            _categoryRepo.Save();
            TempData["Success"] = "Category Deleted Successifully";
                return RedirectToAction("Index");
            
           
        }
    }
}
