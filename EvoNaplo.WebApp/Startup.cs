using EvoNaplo.WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.ApplicationCore.Domains.Users.Facades;
using EvoNaplo.ApplicationCore.Domains.Auth.Services;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.ApplicationCore.Domains.Auth.Facades;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.ApplicationCore.Domains.Projects.Services;
using EvoNaplo.ApplicationCore.Domains.Semesters.Facades;
using EvoNaplo.ApplicationCore.Domains.Projects.Facades;
using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.ApplicationCore.Domains.Comments.Services;
using EvoNaplo.ApplicationCore.Domains.Comments.Facades;

namespace EvoNaplo.WebApp
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
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<MentorService>();
            services.AddScoped<StudentService>();
            services.AddScoped<AdminService>();
            services.AddScoped<UserService>();
            
            services.AddScoped<IAuthFacade, AuthFacade>();
            services.AddScoped<AuthService>();
                        
            services.AddScoped<IRepository<SemesterEntity>, Repository<SemesterEntity>>();
            services.AddScoped<ISemesterFacade, SemesterFacade>();
            services.AddScoped<SemesterService>();

            services.AddScoped<IRepository<ProjectEntity>, Repository<ProjectEntity>>();
            services.AddScoped<IProjectFacade, ProjectFacade>();
            services.AddScoped<ProjectService>();

            services.AddScoped<IRepository<CommentEntity>, Repository<CommentEntity>>();
            services.AddScoped<ICommentFacade, CommentFacade>();
            services.AddScoped<CommentService>();

            services.AddScoped<UserHelper>();
            services.AddScoped<ProjectStudentService>();
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
