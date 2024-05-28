using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudieJobsFinderMyDatabase.Models;
using System.Linq;

public class LogInModel : PageModel
{
    private readonly waldae_dk_db_valjmssqlContext _context;

    [BindProperty]
    public Bruger Input { get; set; }

    public LogInModel(waldae_dk_db_valjmssqlContext context)
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
            
            var bruger = _context.Brugers.FirstOrDefault(u => u.Brugernavn == Input.Brugernavn && u.Adgangskode == Input.Adgangskode);
            if (bruger != null)
            {
                return RedirectToPage("/Index");
            }
        }

        
        ModelState.AddModelError(string.Empty, "Forkert brugernavn eller adgangskode.");
        return Page();
    }
}