using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext db;

        [BindProperty]
        public Category category { get; set; }
        public DeleteModel(ApplicationDBContext dBContext)
        {
            this.db = dBContext;
        }
        public void OnGet(int? id)
        {
            if(id !=0 && id != null)
            {
                category = db.Categories.Where(p => p.Id == id).FirstOrDefault();
            }
            

        }
        public IActionResult OnPost(int? id)
        {
            if (ModelState.IsValid)
            {
                var item = db.Categories.Find(id);
                if (item != null)
                {
                    db.Categories.Remove(item);
                    db.SaveChanges();
                    TempData["Success"] = "Category Deleted Successifully";
                }

                return RedirectToPage("Index"); // Redirect after deletion
            }
            return RedirectToPage();
        }
    }
}
