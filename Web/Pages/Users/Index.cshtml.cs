using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Users
{
    [Authorize(Roles = StaticDefinition.AdminAndUSer)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ApplicationUser> ApplicationUsersList { get; set; }

        public void OnGet(string searchname)
        {
            if (searchname == null)
            {
                searchname = "";
            }
            ApplicationUsersList = db.ApplicationUsers.Where
                (
                    m => m.FullName.ToLower().Contains(searchname.ToLower()) ||
                        m.Email.ToLower().Contains(searchname.ToLower()) ||
                        m.PhoneNumber.ToLower().Contains(searchname.ToLower()) ||
                        m.Address.ToLower().Contains(searchname.ToLower())
                )
                .ToList();
        }
    }
}