namespace Web.Pages.ServicesTypes
{
    [Authorize(Roles = StaticDefinition.AdminAndUSer)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ServicesType> servicesTypes { get; set; }

        public void OnGet()
        {
            servicesTypes = db.servicesTypes.ToList();
        }

        //public IActionResult OnPostDelete(int id)
        //{
        //    var servicesTypes = db.servicesTypes.Find(id);

        //    if (servicesTypes == null)
        //    {
        //        return NotFound();
        //    }
        //    db.servicesTypes.Remove(servicesTypes);
        //    db.SaveChanges();
        //    return RedirectToPage("Index");
        //}
    }
}