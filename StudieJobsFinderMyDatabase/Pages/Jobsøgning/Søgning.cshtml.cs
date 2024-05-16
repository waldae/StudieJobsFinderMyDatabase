using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IActionResult OnPostJobSearch()
        {
            waldae_dk_db_valjmssqlContext context = new waldae_dk_db_valjmssqlContext();
            JobList = context.Jobs.Where(j => j.Kategori.Contains(Input) || j.Titel.Contains(Input)).ToList();
            return Page();
        } 
    }
}