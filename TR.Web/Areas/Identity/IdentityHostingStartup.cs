using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TR.Web.Areas.Identity.Data;
using TR.Web.Data;

[assembly: HostingStartup(typeof(TR.Web.Areas.Identity.IdentityHostingStartup))]
namespace TR.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TRWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TRWebContextConnection")));

                services.AddDefaultIdentity<TRWebUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<TRWebContext>();
            });
        }
    }
}