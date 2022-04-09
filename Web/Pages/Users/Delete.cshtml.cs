using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Users
{
    [Authorize(Roles = StaticDefinition.AdminAndUSer)]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public void OnGet(string id)
        {
            ApplicationUser = db.ApplicationUsers.Find(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var use = db.ApplicationUsers.Find(ApplicationUser.Id);
                db.ApplicationUsers.Remove(use);
                db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}