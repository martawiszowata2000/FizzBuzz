using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Data;
using FizzBuzz.Models;


namespace FizzBuzz.Pages.Numbers
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzz.Data.NumberContext _context;

        public IndexModel(FizzBuzz.Data.NumberContext context)
        {
            _context = context;
        }
        public IList<Number_Result> Number_Results { get;set; }
        public async Task OnGetAsync()
        {
            Number_Results = await _context.Number_Result.ToListAsync();
        }
    }
}
