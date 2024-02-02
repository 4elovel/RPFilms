using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RPFilms.Pages.films
{
    public class ChangeModel : PageModel
    {
        AppDbContext db;
        public ChangeModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnPost(string id, string name, string regisseur, string style, string description, string seances)
        {
            //TODO Seances
            int _id = Convert.ToInt32(id);
            Film? film = db.Films.Include(f => f.Seances).Where(f => f.Id == _id).ToList().FirstOrDefault();
            if (film is not null)
            {
                if (name != "") film.Name = name;
                if (regisseur != "") film.Regisseur = regisseur;
                if (style != "") film.Style = style;
                if (description != "") film.Description = description;
                if (seances != "")
                {
                    film.Seances.Clear();
                    var BufSeanceStr = seances.Split(';');
                    foreach (var s in BufSeanceStr)
                    {
                        var Fragments = s.Split(",");
                        DateTime TimeStart;
                        DateTime TimeEnd;
                        if (DateTime.TryParse(Fragments[0], out TimeStart) && DateTime.TryParse(Fragments[1], out TimeEnd))
                        {
                            Fragments[2] = Fragments[2].Trim();
                            film.Seances.Add(new Seance { TimeStart = TimeStart, TimeEnd = TimeEnd, Duration = Fragments[2] });
                        }
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
