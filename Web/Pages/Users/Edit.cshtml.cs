using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Users
{
    [Authorize(Roles = StaticDefinition.AdminAndUSer)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
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
                use.FullName = ApplicationUser.FullName;
                use.Email = ApplicationUser.Email;
                use.PhoneNumber = ApplicationUser.PhoneNumber;
                use.Address = ApplicationUser.Address;
                use.City = ApplicationUser.City;

                db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}