using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudieJobsFinderMyDatabase.Models;  // Juster namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudieJobsFinderMyDatabase.Pages.Virksomheder
{
    public class GetAllModel : PageModel
    {
        private readonly waldae_dk_db_valjmssqlContext _context;

        public GetAllModel(waldae_dk_db_valjmssqlContext context)
        {
            _context = context;
        }

        public IList<Virksomhed> Virksomheder { get; set; }

        public async Task OnGetAsync()
        {
            Virksomheder = await _context.Virksomheds.ToListAsync();
        }
    }
}

