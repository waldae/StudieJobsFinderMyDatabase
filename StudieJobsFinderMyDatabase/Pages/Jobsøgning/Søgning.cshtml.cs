using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudieJobsFinderMyDatabase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudieJobsFinderMyDatabase.Pages.Jobsøgning
{
    //    public class SøgningModel : PageModel
    //    {
    //        public IList<Job> JobList { get; set; } = new List<Job>();


    //        [BindProperty]
    //        public string Input { get; set; }

    //        public SøgningModel()

    //        {

    //        }

    //        public IActionResult onpostjobsearch()
    //        {
    //            waldae_dk_db_valjmssqlContext context = new waldae_dk_db_valjmssqlContext();
    //            Jobs = context.Jobs.Where(j => j.Kategori.Contains(Input) || j.Titel.Contains(Input)).ToList();
    //            return Page();
    //        }
    //        private readonly waldae_dk_db_valjmssqlContext _context;

    //        public SøgningModel(waldae_dk_db_valjmssqlContext context)
    //        {
    //            _context = context;
    //        }

    //        public IList<Job> Jobs { get; set; } = new List<Job>();

    //        [BindProperty]
    //        public string SearchInput { get; set; }

    //        public async Task OnGetAsync()
    //        {
    //            if (!string.IsNullOrEmpty(SearchInput))
    //            {
    //                JobList = await _context.Jobs
    //                    .Where(j => j.Kategori.Contains(SearchInput) || j.Titel.Contains(SearchInput))
    //                    .ToListAsync();
    //            }
    //        }
    //    }
    //}


    namespace StudieJobsFinderMyDatabase.Pages.Jobsøgning
    {
        public class SøgningModel : PageModel
        {
            [BindProperty]
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

                    Jobs = Jobs.Where(job => job.Kategori.Contains(Input)).ToList();
                }

                return Page();
            }

            private List<SelectListItem> GetCategories()
            {
                
                return new List<SelectListItem>
            {
                //new SelectListItem { Value = "IT", Text = "IT" },
                //new SelectListItem { Value = "Marketing", Text = "Marketing" },
                //new SelectListItem { Value = "Finance", Text = "Finance" }
                // Add more categories as needed
            };
            }

            //    private Task<List<Job>> GetJobsAsync(string input)
            //    {
            //        // Replace with actual jobs retrieval logic
            //        return Task.FromResult(new List<Job>
            //    {
            //        new Job { Titel = "Software Developer", Beskrivelse = "Develop software", Kategori = "IT", Lokation = "Copenhagen" },
            //        new Job { Titel = "Marketing Specialist", Beskrivelse = "Marketing campaigns", Kategori = "Marketing", Lokation = "Aarhus" },
            //        new Job { Titel = "Financial Analyst", Beskrivelse = "Analyze financial data", Kategori = "Finance", Lokation = "Odense" }
            //        // Add more job examples as needed
            //    });
            //    }
            //}

            //public class Job
            //{
            //    public string Titel { get; set; }
            //    public string Beskrivelse { get; set; }
            //    public string Kategori { get; set; }
            //    public string Lokation { get; set; }
            //}
        }
    }
}



