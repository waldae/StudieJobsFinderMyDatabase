using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudieJobsFinderMyDatabase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudieJobsFinderMyDatabase.Pages.Jobsøgning
{

    namespace StudieJobsFinderMyDatabase.Pages.Jobsøgning
    {
        public class SøgningModel : PageModel
        {
            [BindProperty]
            [Display(Name = "Søg efter")]

            public string Input { get; set; }
            [BindProperty]
            public string SelectedCategory { get; set; }
            public List<SelectListItem> Categories { get; set; }
            public List<Job> Jobs { get; set; } = new List<Job>();

            public void OnGet()
            {
                Categories = GetCategories();
                Jobs = new List<Job>();


            }

            public async Task<IActionResult> OnPostJobSearchAsync()
            {
                Categories = GetCategories();

                waldae_dk_db_valjmssqlContext context = new waldae_dk_db_valjmssqlContext();

                Jobs = context.Jobs.ToList();

                if (!string.IsNullOrEmpty(Input))
                {

                    Jobs = Jobs.Where(job => job.Kategori.Contains(Input) ||
                    job.Titel.Contains(Input)).ToList();
                }

                return Page();
            }

            private List<SelectListItem> GetCategories()
            {

                return new List<SelectListItem>
                {

                };
            }

        }
    }
}



