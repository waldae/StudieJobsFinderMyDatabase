using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudieJobsFinderMyDatabase.Models;
using System.Threading.Tasks;

namespace StudieJobsFinderMyDatabase.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly waldae_dk_db_valjmssqlContext _context;

        public EditModel(waldae_dk_db_valjmssqlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs.FirstOrDefaultAsync(m => m.JobId == id);

            if (Job == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jobToUpdate = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == Job.JobId);

            if (jobToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Job>(
                jobToUpdate,
                "Job",
                s => s.Titel, s => s.Beskrivelse, s => s.OffentliggørelsesDato, s => s.Deadline, s => s.Lokation, s => s.Løn, s => s.Kompetencer, s => s.Kategori))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Jobsøgning/Søgning");
            }

            return Page();
        }
    }
}
