using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LogInModel : PageModel
{
    [BindProperty]
    public User Input { get; set; }

    public void OnGet()
    {
        // Intet behøver at gøres ved GET-anmodninger
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Simpel logik til at validere brugernavn og adgangskode
            if (Input.Username == "admin" && Input.Password == "password")
            {
                // Brugerne er korrekt
                // Her kan du udføre yderligere handlinger, f.eks. logge dem ind
                return RedirectToPage("/Index"); // Omdiriger til hjemmesiden
            }
        }

        // Forkert brugernavn eller adgangskode, eller model er ugyldig
        // Vis log ind-siden igen med en fejlmeddelelse
        ModelState.AddModelError(string.Empty, "Forkert brugernavn eller adgangskode.");
        return Page();
    }
}