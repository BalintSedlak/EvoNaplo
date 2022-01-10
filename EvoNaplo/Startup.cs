using EvoNaplo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EvoNaplo.Domains.Users.Services;
using EvoNaplo.Common.DataAccessLayer;
using EvoNaplo.Domains.Users.Models;
using EvoNaplo.Common.DomainFacades;
using EvoNaplo.Common.Models.Entities;
using EvoNaplo.Domains.Users.Facades;
using EvoNaplo.Domains.Auth.Services;

namespace EvoNaplo
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

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<EvoNaploContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddControllers();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<SemesterService>();
            services.AddScoped<MentorService>();
            services.AddScoped<StudentService>();
            services.AddScoped<AdminService>();
            services.AddScoped<UserService>();
            services.AddScoped<AuthService>();
            services.AddScoped<UserHelper>();
            services.AddScoped<IUserFacade, UserFacade>();


            services.AddScoped<ProjectService>();
            services.AddScoped<ProjectStudentService>();
            services.AddScoped<SessionService>();
            services.AddScoped<CommentService>();
            services.AddScoped<AttendanceSheetService>();
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
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
