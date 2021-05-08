using System;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzz.Models
{
    public class Number_Result
    {
        [Key]
        public int Id { get; set; }
        [Range(1, 1000, ErrorMessage ="Podaj liczbę z zakresu 1-1000")] 
        [Required]
        public int Number { get; set; }
        [MaxLength(8)]
        public String Result { get; set; }
        public DateTime Time { get;  set; }
        public string Owner { get; set; }
        public String Check(int nr)
        {
            Result = "";
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
