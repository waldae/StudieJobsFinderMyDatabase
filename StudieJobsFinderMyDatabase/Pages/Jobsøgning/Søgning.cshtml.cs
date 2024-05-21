using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudieJobsFinderMyDatabase.Models;

namespace StudieJobsFinderMyDatabase.Pages.Jobsøgning
{
    public class SøgningModel : PageModel
    {
        public IList<Job> JobList { get; set; } = new List<Job>();


        [BindProperty]
        public string Input { get; set; }

        public SøgningModel()

        {
            
        }

        public IActionResult onpostjobsearch()
        {
            waldae_dk_db_valjmssqlContext context = new waldae_dk_db_valjmssqlContext();
            Jobs = context.Jobs.Where(j => j.Kategori.Contains(Input) || j.Titel.Contains(Input)).ToList();
            return Page();
        }
        private readonly waldae_dk_db_valjmssqlContext _context;

        public SøgningModel(waldae_dk_db_valjmssqlContext context)
        {
            _context = context;
        }

        public IList<Job> Jobs { get; set; } = new List<Job>();

        [BindProperty]
        public string SearchInput { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchInput))
            {
                JobList = await _context.Jobs
                    .Where(j => j.Kategori.Contains(SearchInput) || j.Titel.Contains(SearchInput))
                    .ToListAsync();
            }
        }
    }
}






