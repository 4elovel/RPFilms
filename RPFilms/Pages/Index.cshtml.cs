using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RPFilms.Pages
{
    public class IndexModel : PageModel
    {
        AppDbContext db;


        public IndexModel(AppDbContext db)
        {
            this.db = db;
        }

        public List<Film> Films { get; set; }

        public void OnGet()
        {
            using (db)
            {
                Films = db.Films.Include(f => f.Seances).ToList();
            }
        }
    }
}
