using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext db;

        [BindProperty]
        public Category category { get; set; }
        public CreateModel(ApplicationDBContext dBContext)
        {
            this.db = dBContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() {

            if (!ModelState.IsValid)
            {
                return Page(); // Return to the same page to show validation errors
            }

            db.Categories.Add(category);
            db.SaveChanges();
            TempData["Success"] = "Category Created Successifully";

            return RedirectToPage("Index");
        
        }
    }
}
