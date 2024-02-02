using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPFilms.Pages.films
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.AppDbContext _context;

        public CreateModel(DataAccess.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Films.Add(Film);
            await _context.SaveChangesAsync();

            return Redirect("/films/create");
        }
    }
}
