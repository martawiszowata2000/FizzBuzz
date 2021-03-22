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

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public Number_Result Number_Result { get; set; }
        public static List<Number_Result> PrevNum = new List<Number_Result>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Number_Result.Check(Number_Result.Number);
                Number_Result.Time = System.DateTime.Now;

                PrevNum.Add(Number_Result);

                HttpContext.Session.SetString("SessionNumber", JsonConvert.SerializeObject(PrevNum));
            }
            return Page();
        }
    }
}
