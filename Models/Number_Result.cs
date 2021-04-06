using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class Number_Result
    {
        [Range(1, 1000, ErrorMessage ="Podaj liczbę z zakresu 1-1000"), Required]
        public int Number { get; set; }

        public String Result ="";
        public DateTime Time { get;  set; }
        public String Check(int nr)
        {
            if(nr%3==0)
            {
                Result += "Fizz";
            }
            if(nr%5==0)
            {
                Result += "Buzz";
            }
            return Result;
        }
    }
}
