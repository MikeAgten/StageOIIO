using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentProj.Extensions;
using AppointmentProj.Persistance;
using ContactProj.Domain;
using ContactProj.Extensions;
using ContactProj.Persistance;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelingSalesmanProblemOIIO.Controllers;

namespace TravelingSalesmanProblemOIIO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(ContactRepository));
            services.AddMediatR(typeof(AppointmentRepository));
            services.AddControllers();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.RegisterContactDependencies(Configuration);
            services.RegisterAppointmentDependencies(Configuration);
            services.AddMvc();
            services.AddDbContext<ContactDbContext>();
            services.AddDbContext<AppointmentDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapBlazorHub();
                endpoints.MapRazorPages();
            });
        }
    }
}
