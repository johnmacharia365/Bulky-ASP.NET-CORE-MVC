using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext db;

        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDBContext dBContext)
        {
            this.db = dBContext;
        }
        public void OnGet()
        {
            CategoryList = db.Categories.ToList();
        }
    }
}
