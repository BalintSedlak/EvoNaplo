using EvoNaplo.ApplicationCore.Domains.AttendanceSheets.Facades;
using EvoNaplo.ApplicationCore.Domains.AttendanceSheets.Services;
using EvoNaplo.ApplicationCore.Domains.Auth.Facades;
using EvoNaplo.ApplicationCore.Domains.Auth.Services;
using EvoNaplo.ApplicationCore.Domains.Comments.Facades;
using EvoNaplo.ApplicationCore.Domains.Comments.Services;
using EvoNaplo.ApplicationCore.Domains.Projects.Facades;
using EvoNaplo.ApplicationCore.Domains.Projects.Services;
using EvoNaplo.ApplicationCore.Domains.Semesters.Facades;
using EvoNaplo.ApplicationCore.Domains.Users.Facades;
using EvoNaplo.ApplicationCore.Domains.Users.Services;
using EvoNaplo.Infrastructure.DataAccess;
using EvoNaplo.Infrastructure.DataAccess.Entities;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Helpers;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.Infrastructure.Models.TableConnectors;
using EvoNaplo.WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<EvoNaploContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<MentorService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IAuthFacade, AuthFacade>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<IRepository<SemesterEntity>, Repository<SemesterEntity>>();
builder.Services.AddScoped<ISemesterFacade, SemesterFacade>();
builder.Services.AddScoped<SemesterService>();

builder.Services.AddScoped<IRepository<ProjectEntity>, Repository<ProjectEntity>>();
builder.Services.AddScoped<IProjectFacade, ProjectFacade>();
builder.Services.AddScoped<ProjectService>();

builder.Services.AddScoped<IRepository<CommentEntity>, Repository<CommentEntity>>();
builder.Services.AddScoped<ICommentFacade, CommentFacade>();
builder.Services.AddScoped<CommentService>();

builder.Services.AddScoped<IRepository<Attendance>, Repository<Attendance>>();
builder.Services.AddScoped<IAttendanceFacade, AttendanceFacade>();
builder.Services.AddScoped<AttendanceService>();

builder.Services.AddScoped<IRepository<AttendanceSheet>, Repository<AttendanceSheet>>();
builder.Services.AddScoped<IAttendanceSheetFacade, AttendanceSheetFacade>();
builder.Services.AddScoped<AttendanceSheetService>();

builder.Services.AddScoped<UserHelper>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MySite", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://127.0.0.1:3000", "https://localhost:3000", "https://127.0.0.1:3000")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("MySite");

app.Run();
