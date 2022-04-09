namespace Web.Pages.ServicesTypes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(Services).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToPage("Index");

            //if (ModelState.IsValid)
            //{
            //    var sertype = db.servicesTypes.Find(Services.Id);

            //    sertype.Name = Services.Name;
            //    sertype.Price = Services.Price;

            //    db.SaveChanges();

            //    return RedirectToPage("Index");
            //}
            //return Page();
        }
    }
}