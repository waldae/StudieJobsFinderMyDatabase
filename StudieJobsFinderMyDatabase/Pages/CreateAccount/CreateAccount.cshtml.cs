using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudieJobsFinderMyDatabase.Models;
using System.Linq;

public class CreateAccountModel : PageModel
{
    private readonly waldae_dk_db_valjmssqlContext _context;

    [BindProperty]
    public Bruger Input { get; set; }

    public CreateAccountModel(waldae_dk_db_valjmssqlContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Tjek om brugernavnet allerede eksisterer
            var usernameExists = _context.Brugers.Any(u => u.Brugernavn == Input.Brugernavn);
            if (usernameExists)
            {
                ModelState.AddModelError(string.Empty, "Brugernavnet eksisterer allerede.");
                return Page();
            }

            // Opret brugeren
            _context.Brugers.Add(Input);
            _context.SaveChanges();

            return RedirectToPage("/Index"); // Omdiriger til hjemmesiden efter oprettelse af konto
        }

        // Model er ugyldig, vis formularsiden igen med fejlmeddelelser
        return Page();
    }
}