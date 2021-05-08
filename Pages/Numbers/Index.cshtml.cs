using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzz.Pages.Numbers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzz.Data.NumberContext _context;

        public IndexModel(FizzBuzz.Data.NumberContext context)
        {
            _context = context;
        }
        public IList<Number_Result> Number_Results { get; set; }
        public async Task OnGetAsync()
        {
                Number_Results = await _context.Number_Result.ToListAsync();
                var NumQuery = from Number_Results in _context.Number_Result orderby Number_Results.Time descending select Number_Results;
                Number_Results = NumQuery.Take(20).ToList();
        }
    }
}
