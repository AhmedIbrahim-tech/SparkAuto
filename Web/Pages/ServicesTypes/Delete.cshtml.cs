using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.ServicesTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public ServicesType Services { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Services = db.servicesTypes.Find(id);

            if (Services == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            db.servicesTypes.Remove(Services);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}