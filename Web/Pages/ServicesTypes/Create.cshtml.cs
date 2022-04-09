namespace Web.Pages.ServicesTypes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public ServicesType Services { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.servicesTypes.Add(Services);
                db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}