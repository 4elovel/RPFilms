using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RPFilms.Pages.films
{
    public class SearchModel : PageModel
    {
        AppDbContext db;
        public List<Film> Films { get; set; } = null;
        [BindProperty(Name = "search-element")]
        public string Element { get; set; }
        public SearchModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnPost()
        {
            if (Element is null || Element == "") return;
            using (db)
            {
                Films = db.Films.Include(f => f.Seances).ToList();
                var FilmsTemp = new List<Film>();
                foreach (var i in Films)
                {
                    foreach (var j in i.Seances)
                    {
                        if (j.TimeStart.ToString().Contains(Element))
                        {
                            FilmsTemp.Add(i);
                            break;
                        }//Можна шукати по даті

                    }
                }

                Films = Films.Where(f => f.Name.Contains(Element) ||
                f.Regisseur.Contains(Element) ||
                f.Description.Contains(Element) ||
                f.Style.Contains(Element))
                    .ToList();
                Films.AddRange(FilmsTemp);
            }
        }
    }
}
