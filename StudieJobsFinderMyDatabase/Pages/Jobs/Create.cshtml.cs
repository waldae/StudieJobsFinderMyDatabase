using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudieJobsFinderMyDatabase.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudieJobsFinderMyDatabase.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly waldae_dk_db_valjmssqlContext _context;

        [BindProperty]
        public Job Job { get; set; }

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

            _context.Jobs.Add(Job);

            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToPage();
        }

    }
}