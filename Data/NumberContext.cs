using FizzBuzz.Areas.Identity.Data;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Data
{
    public class NumberContext : IdentityDbContext<FizzBuzzUser>
    {
        public NumberContext() {}
        public NumberContext(DbContextOptions options) : base(options) { }
        public DbSet<Number_Result> Number_Result { get; set; }
    }
}
