using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Models;
using System.Collections.Generic;

namespace FizzBuzz.Pages
{
    public class NumberModel : PageModel
    {
        public Number_Result Number_Result;
        public static List<Number_Result> PrevNum = new List<Number_Result>();

        public void OnGet()
        {
            var SessionNumber = HttpContext.Session.GetString("SessionNumber");
            if (SessionNumber != null)
            {
                PrevNum = JsonConvert.DeserializeObject<List<Number_Result>>(SessionNumber);
            }
        }
    }
}
