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
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzz.Data.NumberContext _context;

        public DeleteModel(FizzBuzz.Data.NumberContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Number_Result = await _context.Number_Result.FindAsync(id);

            if (Number_Result != null)
            {
                _context.Number_Result.Remove(Number_Result);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
