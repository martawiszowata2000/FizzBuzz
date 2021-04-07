using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Data;
using FizzBuzz.Models;

namespace FizzBuzz.Pages.Numbers
{
    public class EditModel : PageModel
    {
        private readonly FizzBuzz.Data.NumberContext _context;

        public EditModel(FizzBuzz.Data.NumberContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Number_Result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Number_ResultExists(Number_Result.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Number_ResultExists(int id)
        {
            return _context.Number_Result.Any(e => e.Id == id);
        }
    }
}
