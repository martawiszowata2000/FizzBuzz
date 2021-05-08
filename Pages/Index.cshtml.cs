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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FizzBuzz.Areas.Identity.Data;

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
        private readonly UserManager<FizzBuzzUser> _userManager;
        private readonly SignInManager<FizzBuzzUser> _signInManager;
        public IndexModel(ILogger<IndexModel> logger, NumberContext context, 
            UserManager<FizzBuzzUser> UserManager, SignInManager<FizzBuzzUser> SignInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = UserManager;
            _signInManager = SignInManager;

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
                if(_signInManager.IsSignedIn(User))
                {
                    Number_Result.Owner = _userManager.GetUserName(User);
                }

                PrevNum.Add(Number_Result);

                HttpContext.Session.SetString("SessionNumber", JsonConvert.SerializeObject(PrevNum));

                _context.Number_Result.Add(Number_Result);
                _context.SaveChangesAsync();

            }
            return Page();
        }
    }
}
