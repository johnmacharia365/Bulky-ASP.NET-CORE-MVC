using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
   
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext db;

        [BindProperty]
        public Category category { get; set; }
        public EditModel(ApplicationDBContext dBContext)
        {
            this.db = dBContext;
        }
        public void OnGet(int? id)
        {
            if (id != 0 && id != null)
            {
                category = db.Categories.Where(p => p.Id == id).FirstOrDefault();
            }
          
        }
        public IActionResult OnPost( int? id)
        {
            if (ModelState.IsValid)
            {
                var item = db.Categories.Find(id);
               
                    item.Name = category.Name;
                    item.DisplayOrder = category.DisplayOrder;
                    db.Categories.Update(item);
                    db.SaveChanges();
                TempData["Success"] = "Category Updated Successifully";

                return RedirectToPage("Index"); // Redirect after deletion

            }
            return RedirectToPage();

           

        }

    }
}
