using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Data;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public Number_Result Number_Result { get; set; }
        public static List<Number_Result> PrevNum = new List<Number_Result>();
        private readonly NumberContext _context;
        public IList<Number_Result> Number_Results { get; set; }
        public IndexModel(ILogger<IndexModel> logger, NumberContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet() 
        {
            Number_Results = _context.Number_Result.ToList();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Number_Result.Check(Number_Result.Number);
                Number_Result.Time = System.DateTime.Now;

                PrevNum.Add(Number_Result);

                HttpContext.Session.SetString("SessionNumber", JsonConvert.SerializeObject(PrevNum));

                _context.Number_Result.Add(Number_Result);
                _context.SaveChangesAsync();

            }
            return Page();
        }
    }
}
