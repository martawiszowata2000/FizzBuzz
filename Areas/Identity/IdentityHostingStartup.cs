using System;
using FizzBuzz.Areas.Identity.Data;
using FizzBuzz.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FizzBuzz.Areas.Identity.IdentityHostingStartup))]
namespace FizzBuzz.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NumberContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FB_DB")));

                services.AddDefaultIdentity<FizzBuzzUser>()
                    .AddEntityFrameworkStores<NumberContext>();
            });
        }
    }
}