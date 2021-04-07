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
    public class DetailsModel : PageModel
    {
        private readonly FizzBuzz.Data.NumberContext _context;

        public DetailsModel(FizzBuzz.Data.NumberContext context)
        {
            _context = context;
        }

        public Number_Result Number_Result { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Number_Result = await _context.Number_Result.FirstOrDefaultAsync(m => m.Id == id);

            if (Number_Result == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
