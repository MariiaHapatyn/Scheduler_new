using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.DataAccess.Implementation;
using Scheduler.DataAccess.Interfaces;
using Scheduler.DataAccess.Models;
using Scheduler.Services.Implementation;
using Scheduler.Services.Interfaces;

namespace Scheduler
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
            services.AddDbContext<SchedulerContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(
                config => config.SignIn.RequireConfirmedEmail = true)
                .AddEntityFrameworkStores<SchedulerContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();

            services.AddMvc();
            services.AddScoped(typeof(IRepository<Group>), typeof(GroupRepository));
            services.AddScoped(typeof(IRepository<Room>), typeof(RoomRepository));
            services.AddScoped(typeof(IRepository<Teacher>), typeof(TeacherRepository));
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<ITeacherService, TeacherService>();


            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
