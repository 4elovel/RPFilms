using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPFilms.Pages.films
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.AppDbContext _context;

        public DeleteModel(DataAccess.AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/films/delete");
        }
    }
}
