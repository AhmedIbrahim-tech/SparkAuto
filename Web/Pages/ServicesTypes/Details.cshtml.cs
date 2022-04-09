namespace Web.Pages.ServicesTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public DetailsModel(ApplicationDbContext db)
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
    }
}