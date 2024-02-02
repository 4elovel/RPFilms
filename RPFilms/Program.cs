namespace RPFilms;
using DataAccess;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        using (AppDbContext dc = new())
        {
            dc.Films.Add(new Entities.Film { Name = "Godzila", Description = "Very good film!!!!", Regisseur = "Ne Znaiy xto", Style = "ABCD" });

            dc.Films.Add(new Entities.Film { Name = "Shrek", Description = "Very good film!!!!", Regisseur = "Ne Znaiy xto", Style = "ABCD" });

            DateTime tempStart = new DateTime(2024, 12, 25, 10, 30, 0);
            DateTime tempEnd = new DateTime(2024, 12, 25, 11, 50, 0);
            dc.SaveChanges();
            dc.Seances.Add(new Entities.Seance { Duration = "1:20", TimeStart = tempStart, TimeEnd = tempEnd, Film = dc.Films.First() });
            dc.Seances.Add(new Entities.Seance { Duration = "1:20", TimeStart = tempStart, TimeEnd = tempEnd, Film = dc.Films.First() });


            dc.Seances.Add(new Entities.Seance { Duration = "1:20", TimeStart = tempStart, TimeEnd = tempEnd, Film = dc.Films.Where(f => f.Id == 2).ToList()[0] });
            dc.Seances.Add(new Entities.Seance { Duration = "1:20", TimeStart = tempStart, TimeEnd = tempEnd, Film = dc.Films.Where(f => f.Id == 2).ToList()[0] });
            dc.SaveChanges();

        }

        string connection = "Data Source=Data.sqlite;";
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();



        app.Run();
    }
}
