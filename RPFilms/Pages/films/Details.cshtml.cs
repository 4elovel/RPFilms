using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RPFilms.Pages.films
{
	public class DetailsModel : PageModel
	{
		AppDbContext db;
		public DetailsModel(AppDbContext db)
		{
			this.db = db;
		}

		public Film Film { get; private set; }

		public void OnGet()
		{
			using (db)
			{
				var id = Convert.ToInt32(RouteData.Values["id"]);
				Film = db.Films.Include(f => f.Seances).Where(f => f.Id == id).ToList()[0];
				if (Film is null)
				{
					Response.Redirect("/Error");
				}
			}
		}
	}
}
