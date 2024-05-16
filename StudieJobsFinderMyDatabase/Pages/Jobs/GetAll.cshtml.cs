using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudieJobsFinderMyDatabase.Models;

namespace StudieJobsFinderMyDatabase.Pages.Jobs
{
    public class GetAllModel : PageModel
    {
        public List<Job> JobList { get; set; } = new List<Job>();

        public void OnGet()
        {
            waldae_dk_db_valjmssqlContext dbContext = new waldae_dk_db_valjmssqlContext();

            JobList = dbContext.Jobs.ToList();
        }
    }
}
