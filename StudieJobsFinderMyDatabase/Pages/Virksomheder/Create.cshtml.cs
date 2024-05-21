using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudieJobsFinderMyDatabase.Models;

namespace StudieJobsFinderMyDatabase.Pages.Virksomheder
{
    public class CreateModel : PageModel
    {
        private readonly waldae_dk_db_valjmssqlContext _context;

        [BindProperty]
        public Virksomhed Virksomhed { get; set; }

        public CreateModel(waldae_dk_db_valjmssqlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Virksomheds.Add(Virksomhed);
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToPage();
        }

    }
}